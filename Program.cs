using HomeCafeApi.Database;
using HomeCafeApi.Endpoints;
using Microsoft.EntityFrameworkCore;

var MyAllowedOrigins = "_myAllowedOrigins";
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("HomeCafeDb");

builder.Services.AddDbContext<HomeCafeDb>(opt => opt.UseNpgsql(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.WriteIndented = true;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowedOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseCors(MyAllowedOrigins);
app.RegisterMenuItemsEndpoints();
app.Run();