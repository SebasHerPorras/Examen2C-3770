using ExamTwo.Data;
using ExamTwo.Interfaces;
using ExamTwo.Repositories;
using ExamTwo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:8080", "http://localhost:8081")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// -------------------------------
// CONTROLLERS
// -------------------------------
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Coffee Machine API",
        Version = "v1",
        Description = "API for managing coffee machine operations with SOLID principles and Repository Pattern"
    });
});

// -------------------------------
// DATABASE SINGLETON
// -------------------------------
builder.Services.AddSingleton<Database>();

// -------------------------------
// REPOSITORIES
// -------------------------------
builder.Services.AddScoped<ICoffeeMachineRepository, CoffeeMachineRepository>();

// -------------------------------
// SERVICES WITH INTERFACES -> DEPENDENCY INJECTION
// -------------------------------
builder.Services.AddScoped<ICoffeeOrderService, CoffeeOrderService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IChangeCalculatorService, ChangeCalculatorService>();

builder.Services.AddTransient<IChangeStrategy, GreedyChangeService>();

// -------------------------------
// LOGGING
// -------------------------------
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

// -------------------------------
// CONFIGURAR URLS
// -------------------------------
builder.WebHost.UseUrls("http://localhost:5059", "https://localhost:7183");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}

app.UseCors("AllowVueFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
