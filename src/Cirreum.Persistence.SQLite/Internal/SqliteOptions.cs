namespace Cirreum.Persistence.Internal;

/// <summary>
/// Options for SQLite connection.
/// </summary>
internal sealed class SqliteOptions {

	/// <summary>
	/// The connection string.
	/// </summary>
	public string? ConnectionString { get; set; }

	/// <summary>
	/// Command timeout in seconds. Default is 30.
	/// </summary>
	public int CommandTimeoutSeconds { get; set; } = 30;

}
