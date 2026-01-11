namespace Cirreum.Persistence;

using Cirreum.Persistence.Configuration;
using Cirreum.Persistence.Extensions;
using Cirreum.Persistence.Health;
using Cirreum.Providers;
using Cirreum.ServiceProvider;
using Cirreum.ServiceProvider.Health;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Service provider registrar for SQLite persistence.
/// </summary>
/// <remarks>
/// <para>
/// This registrar integrates SQLite database connections into the Cirreum service provider framework,
/// enabling dependency injection of <see cref="ISqlConnectionFactory"/> instances with support for:
/// </para>
/// <list type="bullet">
///   <item><description>Multiple named instances using keyed DI services</description></item>
///   <item><description>Configurable service lifetimes (Singleton, Scoped, Transient)</description></item>
///   <item><description>Health check integration with customizable queries</description></item>
/// </list>
/// </remarks>
/// <seealso cref="ISqlConnectionFactory"/>
/// <seealso cref="SqliteSettings"/>
/// <seealso cref="SqliteInstanceSettings"/>
public sealed class SqliteRegistrar() :
	ServiceProviderRegistrar<
		SqliteSettings,
		SqliteInstanceSettings,
		SqliteHealthCheckOptions> {

	/// <inheritdoc/>
	public override ProviderType ProviderType { get; } = ProviderType.Persistence;

	/// <summary>
	/// Gets the name of the data provider associated with this implementation.
	/// </summary>
	public override string ProviderName { get; } = "Sqlite";

	/// <inheritdoc/>
	public override string[] ActivitySourceNames { get; } = [
		"Microsoft.Data.Sqlite",
		"Cirreum.Persistence.Sqlite"
	];

	/// <inheritdoc/>
	protected override void AddServiceProviderInstance(
		IServiceCollection services,
		string serviceKey,
		SqliteInstanceSettings settings) {
		services.AddDbFactories(serviceKey, settings);
	}

	/// <inheritdoc/>
	protected override IServiceProviderHealthCheck<SqliteHealthCheckOptions> CreateHealthCheck(
		IServiceProvider serviceProvider,
		string serviceKey,
		SqliteInstanceSettings settings) {
		return serviceProvider.CreateDapperSqlHealthCheck(settings);
	}

}
