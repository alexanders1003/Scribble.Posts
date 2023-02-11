using MediatR;
using Scribble.Posts.Infrastructure.Features.Commands;
using Scribble.Shared.Infrastructure.Factories;

namespace Scribble.Posts.Web.Features.Commands;

public class DeletePostCommand : IRequest
{
    public DeletePostCommand(Guid postId) => PostId = postId;
    public Guid PostId { get; }
}

public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
{
    private readonly IUnitOfWorkFactory _factory;

    public DeletePostCommandHandler(IUnitOfWorkFactory factory)
        => _factory = factory;

    public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        using var unitOfWork = await _factory.CreateAsync(cancellationToken)
            .ConfigureAwait(false);

        await unitOfWork.ExecuteAsync(new DeletePostDbCommand(request.PostId), cancellationToken)
            .ConfigureAwait(false);

        unitOfWork.Commit();

        return Unit.Value;
    }
}
