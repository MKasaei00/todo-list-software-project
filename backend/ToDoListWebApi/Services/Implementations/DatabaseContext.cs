using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ToDoListWebApi.Models.Persistence;

namespace ToDoListWebApi.Services.Implementations;

public class DatabaseContext : DbContext
{
    private readonly IConfiguration _configuration;
    public virtual DbSet<PersistentUser> Users { get; set; }
    public virtual DbSet<PersistentToDoListObject> ToDoListObjects { get; set; }

    protected DatabaseContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DatabaseContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var connectionString = _configuration["Database"];
        if (!string.IsNullOrWhiteSpace(connectionString))
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        else
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = "(local)",
                IntegratedSecurity = true,
                InitialCatalog = "TestDb"
            };

            optionsBuilder.UseSqlServer(builder.ConnectionString);
        }
    }
}