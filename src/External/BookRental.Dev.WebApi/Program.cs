using Asp.Versioning;
using BookRental.Dev.Application;
using BookRental.Dev.Application.Middleware;
using BookRental.Dev.Application.Pipelines.Caching;
using BookRental.Dev.Infrastructure;
using BookRental.Dev.WebApi.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RedisSettings>(builder.Configuration.GetSection("RedisSettings"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
    config.ReportApiVersions = true;
});

builder.Services.AddExceptionHandler<ExceptionHandler>();

builder.Services
    .AddApplicationDependency(builder.Configuration)
    .AddInfrastructureDependency(builder.Configuration);

builder.Host
    .UseSerilog((context, configuration) =>
    {
        configuration.ReadFrom
        .Configuration(context.Configuration);});

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.ApplyMigration();
}

app.UseExceptionHandler(_ => { });

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
