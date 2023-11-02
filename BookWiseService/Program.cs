using BookWiseService;
using Quartz;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddQuartz(options =>
        {
            options.UseMicrosoftDependencyInjectionJobFactory();

        });

        services.AddQuartzHostedService(options =>
        {
            options.WaitForJobsToComplete = true;
        });

        services.ConfigureOptions<NotificationBackGroundJobSetUp>();
    }).UseWindowsService()
    .Build();

await host.RunAsync();
