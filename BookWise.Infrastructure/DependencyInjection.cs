using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookWise.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<IdentityDBContext>(options =>
                 options.EnableSensitiveDataLogging(true).UseSqlServer(configuration.GetConnectionString("AuthConnection"),
                 sqlServerOptionsAction: sqlOptions =>
                 {
                     options.EnableSensitiveDataLogging(false);
                     sqlOptions.MigrationsAssembly(typeof(IdentityDBContext).GetTypeInfo().Assembly.GetName().Name);
                 }));

            services.AddDbContext<ApplicationDbContext>(options =>
                 options.EnableSensitiveDataLogging(true).UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                 sqlServerOptionsAction: sqlOptions =>
                 {
                     options.EnableSensitiveDataLogging(false);
                     sqlOptions.MigrationsAssembly(typeof(ApplicationDbContext).GetTypeInfo().Assembly.GetName().Name);
                 }));

            return services;
        }

    }
}