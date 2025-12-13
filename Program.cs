using HomeCafeApi.Database;
using HomeCafeApi.Endpoints;
using HomeCafeApi.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var MyAllowedOrigins = "_myAllowedOrigins";
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("HomeCafeDb");

builder.Services.AddDbContext<HomeCafeDb>(opt => opt.UseNpgsql(connectionString));
builder.Services.AddTransient<IMenuItemService, MenuItemsService>();
builder.Services.AddTransient<IOrdersService, OrdersService>();
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

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});


var app = builder.Build();

app.UseCors(MyAllowedOrigins);
app.RegisterMenuItemsEndpoints();
app.RegisterOrdersEndpoints();
app.Run();