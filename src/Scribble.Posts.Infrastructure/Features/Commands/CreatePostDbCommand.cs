using System.Data;
using Dapper;
using Scribble.Shared.Infrastructure;

namespace Scribble.Posts.Infrastructure.Features.Commands;

public class CreatePostDbCommand : IDbRequest<Guid>
{
    private readonly object _parameters;
    private const string Query = """
                  INSERT INTO Posts (Title, Content, CreatedAt)
                  VALUES (@Title, @Content, @CreatedAt)
                  SELECT CAST(SCOPE_IDENTITY() as int)
                  """;

    public CreatePostDbCommand(object parameters)
        => _parameters = parameters;

    public async Task<Guid> ExecuteAsync(IDbConnection connection, IDbTransaction transaction, CancellationToken token)
    {
        return await connection.QuerySingleAsync<Guid>(Query, _parameters, transaction)
            .ConfigureAwait(false);
    }
}