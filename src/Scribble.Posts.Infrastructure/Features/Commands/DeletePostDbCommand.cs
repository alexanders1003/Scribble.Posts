using System.Data;
using Dapper;
using Scribble.Shared.Infrastructure;

namespace Scribble.Posts.Infrastructure.Features.Commands;

public class DeletePostDbCommand : IDbRequest
{
    private readonly object _parameters;
    private const string Query = """
                  DELETE FROM Posts WHERE Id = {id}
                  """;

    public DeletePostDbCommand(object parameters)
        => _parameters = parameters;

    public async Task ExecuteAsync(IDbConnection connection, IDbTransaction transaction,
        CancellationToken token = default)
    {
        await connection.ExecuteAsync(Query, _parameters, transaction)
            .ConfigureAwait(false);
    }
}