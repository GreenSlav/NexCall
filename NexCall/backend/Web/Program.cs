using Web.Extensions;
using Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Регистрация сервисов из Core слоя
builder.Services.AddCoreServices();
// Регистрация сервисов из Infrastructure слоя
builder.Services.AddInfrastructureServices();

// Регистрация БД
builder.Services.RegisterPostgresDatabase(builder.Configuration);
builder.Services.RegisterRedisDatabase(builder.Configuration);

// Регистрация опций
builder.Services.RegisterOptions(builder.Configuration);

builder.Services.AddAuth(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

// Перехват ошибок при обработке запросов
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Автоматически применяем миграции
app.ApplyMigrations();

app.UseHttpsRedirection();
app.UseAuth();

app.Run();