using Wing;

var builder = WebApplication.CreateBuilder(args);

builder.Host.AddWing(builder => builder.AddConsul());

builder.Services.AddWing()
                    .AddJwt()
                    .AddGateWay((downstreams,context) =>
                    {
                        //�˴����ҵ����Ȩ�߼���Ҳ���Խ�payload����������ͨ������ͷת�������η���context.Request.Headers.Add()
                        return Task.FromResult(true);
                    }, new WebSocketOptions
                    {
                        KeepAliveInterval = TimeSpan.FromMinutes(2)
                    });
//.AddEventBus();    

var app = builder.Build();
app.Run();


