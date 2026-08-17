using FinanceTracker.Configuration;
using FinanceTracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.Configure<FinanceSetting>(
    builder.Configuration.GetSection("FinanceSetting"));

builder.Services.AddDbContext<FinanceDbContext>(
    options => options.UseNpgsql
    (
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

var app = builder.Build();

app.MapGet("/Health", (ILogger<Program> logger
    ,IOptions<FinanceSetting> options) =>
{
    logger.LogInformation("Health endpoint");
    var settings = options.Value;
    return new
    {
        status = "healthy",
        currency = settings.defaultcurrency,
    };
});
app.MapControllers();
app.Run();
