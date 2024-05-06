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

// Маршрут для регистрации нового клиента
app.MapPost("/api/clients", async (Client client, RentCarrestalingContext context) =>
{
    // Валидация данных клиента
    if (string.IsNullOrEmpty(client.Фио) || client.ДатаРождения == default)
    {
        return Results.BadRequest("Некорректные данные клиента.");
    }

    context.Clients.Add(client);
    await context.SaveChangesAsync();
    return Results.Created($"/api/clients/{client.IdКлиента}", client);
});

// Маршрут для регистрации нового автомобиля
app.MapPost("/api/cars", async (Car car, RentCarrestalingContext context) =>
{
    // Валидация данных автомобиля
    if (string.IsNullOrEmpty(car.ГосНомер) || car.Цена <= 0)
    {
        return Results.BadRequest("Некорректные данные автомобиля.");
    }

    context.Cars.Add(car);
    await context.SaveChangesAsync();
    return Results.Created($"/api/cars/{car.IdАвтомобиля}", car);
});

// Маршрут для начала аренды
app.MapPost("/api/rentals/start", async (Rental rental, RentCarrestalingContext context) =>
{
    // Проверка доступности автомобиля
    var car = await context.Cars.FindAsync(rental.IdАвтомобиля);
    if (car == null || car.ОтметкаОвозврате.GetValueOrDefault())
    {
        return Results.BadRequest("Автомобиль недоступен для аренды.");
    }

    context.Rentals.Add(rental);
    await context.SaveChangesAsync();
    return Results.Ok();
});

// Маршрут для завершения аренды
app.MapPost("/api/rentals/end", async (int rentalId, RentCarrestalingContext context) =>
{
    var rental = await context.Rentals.FindAsync(rentalId);
    if (rental == null)
    {
        return Results.NotFound("Аренда не найдена.");
    }

    // Обновление данных аренды
    rental.ДатаВозврата = DateTime.Now;
    await context.SaveChangesAsync();
    return Results.Ok();
});

app.Run();
