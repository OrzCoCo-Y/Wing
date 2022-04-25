﻿using FreeSql;
using Microsoft.Extensions.DependencyInjection;
using Wing.Configuration.ServiceBuilder;
using System;
using Wing.Persistence.GateWay;

namespace Wing.Persistence
{
    public static class WingBuilderExtensions
    {
        public static IWingServiceBuilder AddPersistence(this IWingServiceBuilder wingBuilder, string connectionString = "ConnectionStrings:Wing")
        {
            var autoSyncStructure = !string.IsNullOrWhiteSpace(wingBuilder.Configuration["UseAutoSyncStructure"]) && Convert.ToBoolean(wingBuilder.Configuration["UseAutoSyncStructure"]);
            IFreeSql fsql = new FreeSqlBuilder()
                              .UseConnectionString(DataType.SqlServer, wingBuilder.Configuration[connectionString])
                              .UseAutoSyncStructure(autoSyncStructure) //自动同步实体结构到数据库，FreeSql不会扫描程序集，只有CRUD时才会生成表。
                              .Build();
            wingBuilder.Services.AddSingleton(typeof(IFreeSql), serviceProvider => fsql);
            wingBuilder.Services.AddSingleton<ILogService, LogService>();
            wingBuilder.Services.AddFreeRepository();
            return wingBuilder;
        }
    }
}
