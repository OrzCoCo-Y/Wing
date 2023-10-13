using FreeSql;
using Sample.AspNetCoreService;
using System.Security.Claims;
using Wing;

var builder = WebApplication.CreateBuilder(args);

builder.Host.AddWing(builder => builder.AddConsul());

builder.Services.AddControllers();
builder.Services.AddHttpClient();

var fsql = new FreeSqlBuilder()
                              .UseConnectionString(DataType.SqlServer, builder.Configuration["ConnectionStrings:Sample.Wing"])
                              .UseAutoSyncStructure(true) // �Զ�ͬ��ʵ��ṹ�����ݿ⣬FreeSql����ɨ����򼯣�ֻ��CRUDʱ�Ż����ɱ�
                              .Build<SampleWingDbFlag>();
builder.Services.AddSingleton(typeof(IFreeSql<SampleWingDbFlag>), serviceProvider => fsql);
builder.Services.AddSingleton<ITracerService, TracerService>();
builder.Services.AddWing().AddPersistence().AddEventBus().AddJwt(context =>
{
    var user = context.User.Claims.Where(c => c.Type == ClaimTypes.Name).FirstOrDefault().Value;
    return user == "byron";
}).AddAPM(x => x.AddFreeSql().Build(fsql));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
