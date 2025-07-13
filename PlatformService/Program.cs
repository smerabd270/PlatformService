using Microsoft.EntityFrameworkCore;
using PlatformService.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

// Use In-Memory Database
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("InMemDb"));

// Register repository and AutoMapper
builder.Services.AddScoped<IPlatformRepo, PlatformRepo>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add Controllers (Web API)
builder.Services.AddControllers();

// Swagger/OpenAPI support
builder.Services.AddEndpointsApiExplorer(); // Required for minimal APIs and Swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Seed the in-memory database
PrepDb.PrepPopulation(app);

// Map Web API Controllers
app.MapControllers();

app.Run();
