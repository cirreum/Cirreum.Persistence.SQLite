namespace Cirreum.Persistence.Health;

using Cirreum.Health;

/// <summary>
/// Health check options for SQLite instances.
/// </summary>
/// <remarks>
/// Inherits base health check properties from ServiceProviderHealthCheckOptions.
/// </remarks>
public sealed class SqliteHealthCheckOptions : ServiceProviderHealthCheckOptions {

	/// <summary>
	/// SQL query to execute for health check. Default is "SELECT 1".
	/// </summary>
	public string Query { get; set; } = "SELECT 1";

}
