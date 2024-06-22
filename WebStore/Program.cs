using WebStore.Extensions;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services.ConfigureLogging();
}

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();