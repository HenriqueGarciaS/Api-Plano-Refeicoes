using APIPlanoDeReficoes.Context;
using APIPlanoDeReficoes.Repositories;
using APIPlanoDeReficoes.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string localSQLConnection = builder.Configuration.GetConnectionString("localSQLServer");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(localSQLConnection));
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddScoped<IMealPlanService, MealPlanService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IFoodRepository, FoodRepository>();
builder.Services.AddScoped<IMealPlanRepository, MealPlanRepository>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
