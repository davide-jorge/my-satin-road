using LinqToDB;
using LinqToDB.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddInfra(this IServiceCollection services, string connectionString)
    {
        // One AppDb (one DB connection) per HTTP request.
        // The container disposes it automatically when the request ends.
        services.AddScoped(_ => new AppDb(new DataOptions().UsePostgreSQL(connectionString)));

        // Add these as you build each feature (the interfaces live in Service):
        // services.AddSingleton<IPasswordHasher, Argon2PasswordHasher>();
        // services.AddScoped<ICategoryRepository, CategoryRepository>();

        return services;
    }
}