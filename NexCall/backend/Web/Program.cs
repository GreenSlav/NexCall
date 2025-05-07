using Web.Extensions;
using Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Core.Entry).Assembly);
});

// Регистрация БД
builder.Services.RegisterPostgresDatabase(builder.Configuration);
var app = builder.Build();

// Перехват ошибок при обработке запросов
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Автоматически применяем миграции
app.ApplyMigrations();

app.UseHttpsRedirection();

app.Run();