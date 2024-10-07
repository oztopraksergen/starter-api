using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebApplication3;
using WebApplication3.Services.Abstract;
using WebApplication3.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    sqlOptions=>sqlOptions.EnableRetryOnFailure()); });

builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IPasswordHasher,PasswordHasher>();
builder.Services.AddScoped<IBookServices, BookService>();
builder.Services.AddScoped<ILoanServices, LoanService>();

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
