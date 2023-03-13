using Microsoft.EntityFrameworkCore;
using CompanyClaimApi.Models;
using CompanyClaimApi.Data;

var builder = WebApplication.CreateBuilder(args);

//Added Repository
builder.Services.AddScoped<ICompanyClaimsRepository, CompanyClaimsRepository>();

// Add services to the container.

builder.Services.AddControllers();
//Update Company API
builder.Services.AddDbContext<CompanyClaimContext>(opt =>
    opt.UseInMemoryDatabase("CompanyClaim"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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