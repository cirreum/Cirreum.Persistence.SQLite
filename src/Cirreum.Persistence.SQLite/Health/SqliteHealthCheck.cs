namespace Cirreum.Persistence.Health;

using Cirreum.Persistence.Internal;
using Cirreum.ServiceProvider.Health;
using Microsoft.Extensions.Diagnostics.HealthChecks;

/// <summary>
/// Health check for SQLite connections.
/// </summary>
internal sealed class SqliteHealthCheck(
	SqliteOptions options,
	SqliteHealthCheckOptions healthOptions
) : IServiceProviderHealthCheck<SqliteHealthCheckOptions> {

	/// <inheritdoc/>
	public SqliteHealthCheckOptions HealthOptions => healthOptions;

	/// <inheritdoc/>
	public async Task<HealthCheckResult> CheckHealthAsync(
		HealthCheckContext context,
		CancellationToken cancellationToken = default) {

		try {
			var factory = new SqliteConnectionFactory(options);
			await using var connection = await factory.CreateSqliteConnectionAsync(cancellationToken);

			await using var command = connection.CreateCommand();
			command.CommandText = healthOptions.Query;
			command.CommandTimeout = (int)(healthOptions.Timeout?.TotalSeconds ?? 5);

			await command.ExecuteScalarAsync(cancellationToken);

			return HealthCheckResult.Healthy("SQLite connection is healthy.");

		} catch (Exception ex) {
			return HealthCheckResult.Unhealthy(
				"SQLite connection failed.",
				exception: ex);
		}

	}

}
