using ToDoListWebApi.Services.Abstractions;
using ToDoListWebApi.Services.Implementations;

namespace ToDoListWebApi.DI;

public static class DependencyInstaller
{
    public static IServiceCollection InstallAppDependencies(this IServiceCollection collection)
    {
        collection.AddDbContext<DatabaseContext>();
        collection.AddSingleton<IActiveUsers, ActiveUsers>();
        collection.AddTransient<IAuthService, AuthService>();
        collection.AddTransient<IAuthPersistenceService, AuthPersistenceService>();
        collection.AddTransient<IPasswordHashCreator, PasswordHashCreator>();

        return collection;
    }
}