﻿using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Wing;
using Wing.Converter;
using Wing.EventBus;
using Wing.Persistence.GateWay;

namespace Wing.GateWay.EventBus
{
    [Subscribe(QueueMode.DLX)]
    public class LogConsumerFail : ISubscribe<Log>
    {
        public async Task<bool> Consume(Log log)
        {
            var logger = ServiceLocator.GetRequiredService<ILogger<LogConsumerFail>>();
            var json = ServiceLocator.GetRequiredService<IJson>();
            try
            {
                var logService = ServiceLocator.GetRequiredService<ILogService>();
                if (await logService.Any(log.Id))
                {
                    return true;
                }

                var result = await logService.Add(log);
                if (result <= 0)
                {
                    logger.LogError($"数据库保存失败，请求日志：{json.Serialize(log)}");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "发生异常，请求日志：{0}", json.Serialize(log));
            }

            return true;
        }
    }
}
