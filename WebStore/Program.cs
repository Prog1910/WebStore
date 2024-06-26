using Contracts;

using WebStore.Extensions;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services.ConfigureLogging();
    builder.Services.ConfigureRepositoryManager();
    builder.Services.ConfigureSqlContext(builder.Configuration);
    builder.Services.ConfigureServiceManager();
    builder.Services.ConfigureMapping();
    builder.Services.ConfigureModelStateFilter();
    builder.Services.ConfigureActionFilters();
    builder.Services.ConfigureSwagger();
}

builder.Services.AddControllers()
    .AddApplicationPart(typeof(WebStore.Presentation.AssemnblyReference).Assembly);

var app = builder.Build();

{
    app.ConfigureExceptionHandling(app.Services.GetRequiredService<ILoggerManager>());

    app.UseSwagger();
    app.UseSwaggerUI(opts => opts.SwaggerEndpoint("/swagger/v1/swagger.json", "Web Store API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();