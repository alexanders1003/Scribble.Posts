using System.Data;
using Dapper;
using Scribble.Posts.Models;
using Scribble.Shared.Infrastructure;

namespace Scribble.Posts.Infrastructure.Features.Queries;

public class GetAllUserPostsByIdDbQuery : IDbRequest<IEnumerable<PostEntity>>
{
    private readonly object _parameters;
    private const string Query = """
              SELECT * FROM Posts
              WHERE AuthorId = @UserId
              """;

    public GetAllUserPostsByIdDbQuery(object parameters)
        => _parameters = parameters;

    public async Task<IEnumerable<PostEntity>> ExecuteAsync(IDbConnection connection, IDbTransaction transaction, CancellationToken token)
    {
        return await connection.QueryAsync<PostEntity>(Query, _parameters, transaction)
            .ConfigureAwait(false);
    }
}