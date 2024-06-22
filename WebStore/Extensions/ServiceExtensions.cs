using Contracts;
using LoggerService;

namespace WebStore.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureLogging(this IServiceCollection services)
        => services.AddSingleton<ILoggerManager, LoggerManager>();
}