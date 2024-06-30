using InvestmentPortfolioManagement.Notification.Email;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPortfolioManagement.Notification
{
    public static class QuartzConfig
    {
        public static async Task<IScheduler> Start()
        {
            // Configuração do Quartz
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            IScheduler scheduler = await schedulerFactory.GetScheduler();
            await scheduler.Start();

            await ScheduleEmailJob(scheduler);

            return scheduler;
        }
        private static async Task ScheduleEmailJob(IScheduler scheduler)
        {
            IJobDetail job = JobBuilder.Create<EmailSender>()
                .WithIdentity("emailJob", "group1")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity("emailTrigger", "group1")
            .StartNow()
            .WithDailyTimeIntervalSchedule(x => x
                .OnEveryDay()
                .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(8, 0))  
                .WithIntervalInHours(24))  
            .Build();

            // Agendar o job com o trigger
            await scheduler.ScheduleJob(job, trigger);
        }
    }
}
