using EcomerceApp.Data;
using EconomicApp.Middlewares;
using EconomicApp.Models.Domain;
using EconomicApp.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EconomicAppDbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("EconomicAppConnectionString")));

builder.Services.AddScoped<ICostFileRepository, LocalCostFileRepository>();

builder.Services.AddScoped<IGenericRepository<Cost>, SQLGenericRepository<Cost>>();
builder.Services.AddScoped<IGenericRepository<Income>, SQLGenericRepository<Income>>();
builder.Services.AddScoped<IGenericRepository<CostType>, SQLGenericRepository<CostType>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "CostFiles")),
    RequestPath = "/CostFiles"
});

app.MapControllers();

app.Run();
