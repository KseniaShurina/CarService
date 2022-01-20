using CarService.Infrastructure.Abstractions;
using CarService.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CarService.Infrastructure.Configuration
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextFactory<DefaultDbContext>(optionsBuilder =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder
                    .UseNpgsql(connectionString, o =>
                        o.MigrationsAssembly(typeof(ServiceCollectionExtension).Assembly.GetName().Name))
                    .UseLoggerFactory(DebuggerLoggerFactory)
                    .EnableSensitiveDataLogging();
            });

            services.AddSingleton<IDbContextFactory, DbContextFactory>();

            return services;
        }

        private static readonly ILoggerFactory DebuggerLoggerFactory = new LoggerFactory(new[] {
            new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
        });
    }
}
