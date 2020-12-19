﻿using System;
using System.Threading.Tasks;
using Wing.EventBus;

namespace AspNetCoreService.EventBus
{
    [Subscribe(QueueMode.DLX)]
    public class UserConsumerFail : ISubscribe<User>
    {
        public Task<bool> Consume(User eventMessage)
        {
            Console.WriteLine($"姓名：{eventMessage.Name}，年龄：{eventMessage.Age}，EventId：{eventMessage.EventId}，CreateTime：{eventMessage.CreateTime}");
            return Task.FromResult(true);
        }
    }
}
