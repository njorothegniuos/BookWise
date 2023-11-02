using Quartz;

namespace BookWiseService
{
    [DisallowConcurrentExecution]
    public class NotificationBackGroundJobs : IJob
    {
        private readonly ILogger<NotificationBackGroundJobs> _logger;
        IConfiguration _configuration;
        public NotificationBackGroundJobs(ILogger<NotificationBackGroundJobs> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;

        }
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {

               //ToDo:Add logic
            }
            catch (Exception ex)
            {
                _logger.LogError($"NotificationBackGroundJobs = > {ex.Message}");
            }

            await Task.CompletedTask;
        }
    }
}
