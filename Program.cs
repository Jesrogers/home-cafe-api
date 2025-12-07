using HomeCafeApi.Database;
using HomeCafeApi.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<HomeCafeDb>(opt => opt.UseInMemoryDatabase("HomeCafeDb"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.WriteIndented = true;
});

var app = builder.Build();

app.RegisterMenuItemsEndpoints();
app.Run();
