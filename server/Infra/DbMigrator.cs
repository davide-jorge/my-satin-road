using DbUp;

public static class DbMigrator
{
    public static void Run(string directConnectionString)
    {
        var upgrader = DeployChanges.To
            .PostgresqlDatabase(directConnectionString)
            .WithScriptsEmbeddedInAssembly(typeof(DbMigrator).Assembly)
            .LogToConsole()
            .Build();

        var result = upgrader.PerformUpgrade();
        if (!result.Successful) throw result.Error;
    }
}