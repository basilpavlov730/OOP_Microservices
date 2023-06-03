// ��� ������� ��������� ���������� ���������� � ����� �����
// �� ��������� ����������� ������� �� ��������� Swagger (����� �������� � launchSettings)
// ��� �������������� ������� ���������� ��������: �� ������� (Solution) ������ ��� -> ��������� -> ����� ��������� -> ����������� ������ -> ��������� ����������� �������� -> "������"

using OOP_Microservices.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// �� ���� �������, ������� ������������ � ���������, ���� � ������������ ������ ������ ���������, �� ������ ���� ����� ������� ��������� ��������������� ������
// .AddScoped - ��������� ������ ��������� ������ ��� ����� � "�����" � ������ ������ ������� � ������, ������������� ������ �����
// .AddSingletone - ��������� ������ ��������� ���� ��� (��� ������ ��������� � ������, ������������� ������ �����) � � ����������� � ����������� ����� ������������ ������ ���� ��������� ������
// .AddTransient - ��������� ������ ��������� ������ ��� (������ ��� �����)
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
