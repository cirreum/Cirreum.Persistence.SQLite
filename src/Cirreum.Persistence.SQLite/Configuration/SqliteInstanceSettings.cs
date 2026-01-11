namespace Cirreum.Persistence.Configuration;

using Cirreum.Persistence.Health;
using Cirreum.ServiceProvider.Configuration;

/// <summary>
/// Instance-specific settings for a Dapper SQLite database connection.
/// </summary>
/// <remarks>
/// <para>
/// Each instance represents a single database connection configuration, allowing for multiple
/// database connections within the same application.
/// </para>
/// <para>
/// The connection factory is registered as a singleton. Individual connections are managed
/// by SQLite's connection handling.
/// </para>
/// </remarks>
/// <seealso cref="SqliteSettings"/>
public sealed class SqliteInstanceSettings :
	ServiceProviderInstanceSettings<SqliteHealthCheckOptions> {

	/// <summary>
	/// Command timeout in seconds. Default is 30.
	/// </summary>
	public int CommandTimeoutSeconds { get; set; } = 30;

	/// <inheritdoc/>
	public override SqliteHealthCheckOptions? HealthOptions { get; set; }

}
