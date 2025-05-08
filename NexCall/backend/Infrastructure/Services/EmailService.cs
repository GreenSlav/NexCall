using Core.Abstractions;
using Core.Options;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Infrastructure.Services;

/// <summary>
/// Сервис для отправки электронных писем
/// </summary>
public class EmailService : IEmailService
{
    private readonly EmailSettingsOptions _settings;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="settings">Опции почты</param>
    public EmailService(IOptions<EmailSettingsOptions> settings)
    {
        _settings = settings.Value;
    }

    /// <inheritdoc />
    public async Task SendVerificationCodeAsync(string email, int code)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("My App", _settings.FromAddress));
        message.To.Add(MailboxAddress.Parse(email));
        message.Subject = "Код подтверждения регистрации";

        message.Body = new TextPart("plain")
        {
            Text = $"Ваш код подтверждения: {code}"
        };

        using var client = new SmtpClient();
        await client.ConnectAsync(_settings.SmtpServer, _settings.Port, _settings.UseSsl);
        await client.AuthenticateAsync(_settings.Username, _settings.Password);
        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }
}