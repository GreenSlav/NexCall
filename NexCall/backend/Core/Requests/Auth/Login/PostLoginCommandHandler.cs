using MediatR;

namespace Core.Requests.Auth.Login;

/// <summary>
/// Обработчик команды <see cref="PostLoginCommand"/>
/// </summary>
public class PostLoginCommandHandler : IRequestHandler<PostLoginCommand>
{
    public Task Handle(PostLoginCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}