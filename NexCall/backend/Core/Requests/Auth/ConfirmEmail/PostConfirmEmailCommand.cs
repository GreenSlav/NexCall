using Contracts.Requests.Auth.ConfirmEmail;
using Contracts.Requests.Auth.Registration;
using MediatR;

namespace Core.Requests.Auth.ConfirmEmail;

/// <summary>
/// Класс команды подтверждения почты
/// </summary>
public class PostConfirmEmailCommand : PostConfirmEmailRequest, IRequest
{
}