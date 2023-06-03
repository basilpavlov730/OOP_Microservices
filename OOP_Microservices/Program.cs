// При запуске программы выполнение начинается с этого файла
// По умолчанию открывается браузер со страницей Swagger (можно поменять в launchSettings)
// Для одновременного запуска нескольких проектов: на Решении (Solution) нажать ПКМ -> Свойсвтва -> Общие свойсвтва -> Запускаемый проект -> Несколько запускаемых проектов -> "Запуск"

using OOP_Microservices.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Во всех классах, которые используются в программе, если в конструкторе класса указан интерфейс, то вместо него будет передан экземпляр соответсвующего класса
// .AddScoped - экземпляр класса создается каждый раз новый и "живет" в рамках одного запроса к классу, использующему данный класс
// .AddSingletone - экземпляр класса создается один раз (при первом обращении к классу, использующему данный класс) и в последующем в конструктор будет передаваться именно этот экземпляр класса
// .AddTransient - экземпляр класса создается каждый раз (каждый раз новый)
builder.Services.AddScoped<IUsersManger, UsersManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
