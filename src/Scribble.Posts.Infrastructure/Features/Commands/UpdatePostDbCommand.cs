using System.Data;
using Dapper;
using Scribble.Shared.Infrastructure;

namespace Scribble.Posts.Infrastructure.Features.Commands;

public class UpdatePostDbCommand : IDbRequest
{
    private readonly object _parameters;
    private const string Query = """
                  UPDATE Posts
                  SET Title = @Title, Content = @Content, CreatedAt = @CreatedAt
                  """;

    public UpdatePostDbCommand(object parameters)
        => _parameters = parameters;

    public async Task ExecuteAsync(IDbConnection connection, IDbTransaction transaction,
        CancellationToken token = default)
    {
        await connection.ExecuteAsync(Query, _parameters, transaction)
            .ConfigureAwait(false);
    }
}