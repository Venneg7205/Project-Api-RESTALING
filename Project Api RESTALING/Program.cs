using Microsoft.EntityFrameworkCore;
using Project_Api_RESTALING.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RentCarrestalingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RentCarrestalingDatabase")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ������� ��� ����������� ������ �������
app.MapPost("/api/clients", async (Client client, RentCarrestalingContext context) =>
{
    // ��������� ������ �������
    if (string.IsNullOrEmpty(client.���) || client.������������ == default)
    {
        return Results.BadRequest("������������ ������ �������.");
    }

    context.Clients.Add(client);
    await context.SaveChangesAsync();
    return Results.Created($"/api/clients/{client.Id�������}", client);
});

// ������� ��� ����������� ������ ����������
app.MapPost("/api/cars", async (Car car, RentCarrestalingContext context) =>
{
    // ��������� ������ ����������
    if (string.IsNullOrEmpty(car.��������) || car.���� <= 0)
    {
        return Results.BadRequest("������������ ������ ����������.");
    }

    context.Cars.Add(car);
    await context.SaveChangesAsync();
    return Results.Created($"/api/cars/{car.Id����������}", car);
});

// ������� ��� ������ ������
app.MapPost("/api/rentals/start", async (Rental rental, RentCarrestalingContext context) =>
{
    // �������� ����������� ����������
    var car = await context.Cars.FindAsync(rental.Id����������);
    if (car == null || car.����������������.GetValueOrDefault())
    {
        return Results.BadRequest("���������� ���������� ��� ������.");
    }

    context.Rentals.Add(rental);
    await context.SaveChangesAsync();
    return Results.Ok();
});

// ������� ��� ���������� ������
app.MapPost("/api/rentals/end", async (int rentalId, RentCarrestalingContext context) =>
{
    var rental = await context.Rentals.FindAsync(rentalId);
    if (rental == null)
    {
        return Results.NotFound("������ �� �������.");
    }

    // ���������� ������ ������
    rental.������������ = DateTime.Now;
    await context.SaveChangesAsync();
    return Results.Ok();
});

app.Run();
