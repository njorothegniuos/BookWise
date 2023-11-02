using Microsoft.Extensions.Options;
using Quartz;

namespace BookWiseService
{
    public class NotificationBackGroundJobSetUp : IConfigureOptions<QuartzOptions>
    {
        IConfiguration _configuration;
        public NotificationBackGroundJobSetUp(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Configure(QuartzOptions options)
        {
            int _time = Convert.ToInt32(_configuration["NotificationJob_Interval"]);
            var jobKey = JobKey.Create(nameof(NotificationBackGroundJobs));

            options.AddJob<NotificationBackGroundJobs>(jobBuilder => jobBuilder.WithIdentity(jobKey))
            .AddTrigger(trigger =>
            trigger
            .ForJob(jobKey)
            .WithSimpleSchedule(schedule =>
            schedule.WithIntervalInSeconds(_time).RepeatForever()));
        }
    }
}
