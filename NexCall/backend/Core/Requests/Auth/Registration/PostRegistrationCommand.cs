using Contracts.Requests.Auth.Registration;
using MediatR;

namespace Core.Requests.Auth.Registration;

/// <summary>
/// Класс команды для регистрации
/// </summary>
public class PostRegistrationCommand : PostRegistrationRequest, IRequest<RegistrationVerificationResponse>
{
}