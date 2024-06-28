using Contracts;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NLog;
using Repository;
using Service;
using Service.Contracts;
using WebStore.Presentation.ActionFilters;

namespace WebStore.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureLogging(this IServiceCollection services)
    {
        LogManager.Setup().LoadConfigurationFromFile("Config/nlog.config");
        services.AddSingleton<ILoggerManager, LoggerManager>();
    }

    public static void ConfigureRepositoryManager(this IServiceCollection services)
        => services.AddScoped<IRepositoryManager, RepositoryManager>();

    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        => services.AddDbContext<RepositoryContext>(opts
            => opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

    public static void ConfigureSwagger(this IServiceCollection services)
        => services.AddSwaggerGen(opts
            => opts.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Web Store API"
            }));

    public static void ConfigureServiceManager(this IServiceCollection services)
        => services.AddScoped<IServiceManager, ServiceManager>();

    public static void ConfigureMapping(this IServiceCollection services)
        => services.AddAutoMapper(typeof(Program));

    public static void ConfigureModelStateFilter(this IServiceCollection services)
        => services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

    public static void ConfigureActionFilters(this IServiceCollection services)
        => services.AddScoped<ValidationFilterAttribute>();
}