using System.Data;
using Dapper;
using Scribble.Posts.Models;
using Scribble.Shared.Infrastructure;

namespace Scribble.Posts.Infrastructure.Features.Queries;

public class GetPostByIdDbQuery : IDbRequest<PostEntity>
{
    private readonly object _parameters;
    private const string Query = """
              SELECT * FROM Posts WHERE Id = @Id
              """;
    public GetPostByIdDbQuery(object parameters)
        => _parameters = parameters;

    public async Task<PostEntity> ExecuteAsync(IDbConnection connection, IDbTransaction
        transaction, CancellationToken token = default)
    {
        return await connection
            .QueryFirstOrDefaultAsync<PostEntity>(Query, _parameters, transaction)
            .ConfigureAwait(false);
    }
}