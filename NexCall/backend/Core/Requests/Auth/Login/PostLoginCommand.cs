using Contracts.Requests.Auth.Login;
using MediatR;

namespace Core.Requests.Auth.Login;

/// <summary>
/// Класс команды для входа
/// </summary>
public class PostLoginCommand : PostLoginRequest, IRequest
{
}