using Contracts;
using LoggerService;
using Microsoft.OpenApi.Models;
using NLog;

namespace WebStore.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureLogging(this IServiceCollection services)
    {
        LogManager.Setup().LoadConfigurationFromFile("Config/nlog.config");
        services.AddSingleton<ILoggerManager, LoggerManager>();
    }

    public static void ConfigureSwagger(this IServiceCollection services)
        => services.AddSwaggerGen(opts
            => opts.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Web Store API"
            }));
}