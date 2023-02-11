using AutoMapper;
using MediatR;
using Scribble.Posts.Infrastructure.Features.Queries;
using Scribble.Posts.Web.Models;
using Scribble.Shared.Infrastructure;
using Scribble.Shared.Infrastructure.Factories;

namespace Scribble.Posts.Web.Features.Queries;

public class GetPostByIdQuery : IRequest<PostEntityCreateViewModel>
{
    public GetPostByIdQuery(Guid id) => Id = id;
    public Guid Id { get; }
}

public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, PostEntityCreateViewModel>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWorkFactory _factory;

    public GetPostByIdQueryHandler(IMapper mapper, IUnitOfWorkFactory factory)
        => (_mapper, _factory) = (mapper, factory);

    public async Task<PostEntityCreateViewModel> Handle(GetPostByIdQuery query, CancellationToken cancellationToken)
    {
        using var unitOfWork = await _factory.CreateAsync(cancellationToken);

        var entity = await unitOfWork
            .ExecuteAsync(new GetPostByIdDbQuery(query.Id), cancellationToken)
            .ConfigureAwait(false);

        return _mapper.Map<PostEntityCreateViewModel>(entity);
    }
}