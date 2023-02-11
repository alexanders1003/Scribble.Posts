using MediatR;
using Scribble.Posts.Infrastructure.Features.Commands;
using Scribble.Posts.Web.Models;
using Scribble.Shared.Infrastructure.Factories;

namespace Scribble.Posts.Web.Features.Commands;

public class UpdatePostCommand : IRequest
{
    public UpdatePostCommand(PostEntityUpdateViewModel model) => Model = model;
    public PostEntityUpdateViewModel Model { get; }
}

public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand>
{
    private readonly IUnitOfWorkFactory _factory;

    public UpdatePostCommandHandler(IUnitOfWorkFactory factory)
        => _factory = factory;

    public async Task<Unit> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        using var unitOfWork = await _factory.CreateAsync(cancellationToken);

        await unitOfWork.ExecuteAsync(new UpdatePostDbCommand(request.Model), cancellationToken)
            .ConfigureAwait(false);

        unitOfWork.Commit();

        return Unit.Value;
    }
}