using MediatR;
using Scribble.Posts.Infrastructure.Features.Commands;
using Scribble.Posts.Web.Models;
using Scribble.Shared.Infrastructure.Factories;

namespace Scribble.Posts.Web.Features.Commands;

public class CreatePostCommand : IRequest<Guid>
{
    public CreatePostCommand(PostEntityCreateViewModel model)
        => Model = model;
    public PostEntityCreateViewModel Model { get; }
}

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Guid>
{
    private readonly IUnitOfWorkFactory _factory;

    public CreatePostCommandHandler(IUnitOfWorkFactory factory)
        => _factory = factory;

    public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        using var unitOfWork = await _factory.CreateAsync(cancellationToken);

        var postId = await unitOfWork
            .ExecuteAsync(new CreatePostDbCommand(request.Model), cancellationToken)
            .ConfigureAwait(false);

        unitOfWork.Commit();

        return postId;
    }
}