using AutoMapper;
using MediatR;
using Scribble.Posts.Infrastructure.Features.Queries;
using Scribble.Posts.Web.Models;
using Scribble.Shared.Infrastructure.Factories;

namespace Scribble.Posts.Web.Features.Queries;

public class GetAllUserPostsByIdQuery : IRequest<IEnumerable<PostEntityViewModel>>
{
    public GetAllUserPostsByIdQuery(Guid userId) => UserId = userId;
    public Guid UserId { get; }
}

public class GetAllUserPostsByIdQueryHandler : IRequestHandler<GetAllUserPostsByIdQuery,
    IEnumerable<PostEntityViewModel>?>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWorkFactory _factory;

    public GetAllUserPostsByIdQueryHandler(IMapper mapper, IUnitOfWorkFactory factory)
        => (_mapper, _factory) = (mapper, factory);

    public async Task<IEnumerable<PostEntityViewModel>?> Handle(GetAllUserPostsByIdQuery
        request, CancellationToken cancellationToken)
    {
        using var unitOfWork = await _factory.CreateAsync(cancellationToken);

        var entities = await unitOfWork
            .ExecuteAsync(new GetAllUserPostsByIdDbQuery(request.UserId), cancellationToken)
            .ConfigureAwait(false);

        return entities?.Select(entity => _mapper.Map<PostEntityViewModel>(entity));
    }
}