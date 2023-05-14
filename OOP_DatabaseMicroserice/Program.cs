using Microsoft.EntityFrameworkCore;
using OOP_DatabaseMicroserice.DataBase;
using OOP_Microservices.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Добавление контекста данных к 
builder.Services.AddDbContext<UsersContext>(options =>
                options.UseSqlServer("Server=localhost;Database=myUsersDataBase;Trusted_Connection=True; TrustServerCertificate=true"));

builder.Services.AddScoped<IUsersManger, UsersManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapControllers();

app.Run();
