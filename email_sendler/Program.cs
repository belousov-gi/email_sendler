using System.Net.Mime;
using email_sendler.DataLayer;
using email_sendler.Interfaces;
using email_sendler.LogicLayer;
using email_sendler.Models;
using email_sendler.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
// builder.Services.AddScoped<MailManager>();
builder.Services.AddScoped<IStorage, DbStorageManager>();

builder.Services.Configure<SmtpServiceConfiguration>(builder.Configuration.GetSection("SmtpConfiguration"));
builder.Services.AddScoped<SmtpService>();

string connectionStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MySqlStorage>(options =>
    options.UseMySql(connectionStr, new MySqlServerVersion(new Version(8, 0, 32))), ServiceLifetime.Transient);

builder.Services.AddDbContext<MySqlStorage>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();