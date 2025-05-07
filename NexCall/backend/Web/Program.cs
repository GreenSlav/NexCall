using Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Регистрация БД
builder.Services.RegisterPostgresDatabase(builder.Configuration);
var app = builder.Build();

// Автоматически применяем миграции
app.ApplyMigrations();

app.UseHttpsRedirection();

app.Run();