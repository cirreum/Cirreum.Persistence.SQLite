namespace Cirreum.Persistence.Internal;

using Dapper;
using System.Threading;

/// <summary>
/// SQLite connection factory.
/// </summary>
internal sealed class SqliteConnectionFactory(
	SqliteOptions options
) : ISqlConnectionFactory {

	static SqliteConnectionFactory() {
		SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
		SqlMapper.AddTypeHandler(new TimeOnlyTypeHandler());
	}

	private readonly string _connectionString = options.ConnectionString
			?? throw new InvalidOperationException("ConnectionString is required.");
	private readonly int _commandTimeoutSeconds = options.CommandTimeoutSeconds;

	/// <inheritdoc />
	public int CommandTimeoutSeconds => _commandTimeoutSeconds;

	/// <inheritdoc />
	public async Task<ISqlConnection> CreateConnectionAsync(CancellationToken cancellationToken = default) {
		var conn = await this.CreateSqliteConnectionAsync(cancellationToken);
		return new SqliteConnection(conn, _commandTimeoutSeconds);
	}

	internal async Task<Microsoft.Data.Sqlite.SqliteConnection> CreateSqliteConnectionAsync(CancellationToken cancellationToken = default) {
		var connection = new Microsoft.Data.Sqlite.SqliteConnection(_connectionString);
		await connection.OpenAsync(cancellationToken);
		return connection;
	}

}