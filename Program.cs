var builder = WebApplication.CreateBuilder(args);

// 1. Отримуємо порт від Railway або використовуємо 5000 для локального запуску
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";

// 2. Налаштовуємо сервер слухати саме цей порт
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(int.Parse(port));
});

// Додаємо сервіси
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 3. Вмикаємо Swagger (інтерфейс для тестування) завжди, навіть на сервері
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();