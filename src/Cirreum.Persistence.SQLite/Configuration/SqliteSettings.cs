namespace Cirreum.Persistence.Configuration;

using Cirreum.Persistence.Health;
using Cirreum.ServiceProvider.Configuration;

/// <summary>
/// Configuration settings container for Dapper SQLite persistence provider.
/// </summary>
/// <remarks>
/// This class serves as the root configuration type for the Dapper SQLite provider,
/// containing a collection of <see cref="SqliteInstanceSettings"/> for configuring
/// multiple database instances.
/// </remarks>
/// <seealso cref="SqliteInstanceSettings"/>
/// <seealso cref="SqliteHealthCheckOptions"/>
public sealed class SqliteSettings :
	ServiceProviderSettings<
		SqliteInstanceSettings,
		SqliteHealthCheckOptions>;
