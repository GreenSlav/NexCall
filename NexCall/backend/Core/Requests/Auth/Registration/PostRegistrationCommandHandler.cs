using MediatR;

namespace Core.Requests.Auth.Registration;

/// <summary>
/// Класс обработчика команды регистрации
/// </summary>
public class PostRegistrationCommandHandler : IRequestHandler<PostRegistrationCommand>
{
    public Task Handle(PostRegistrationCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}