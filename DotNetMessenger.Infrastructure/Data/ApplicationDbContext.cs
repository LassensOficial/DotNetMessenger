using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DotNetMessenger.Domain.Entities;

namespace DotNetMessenger.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Chat> Chats { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<User> Users { get; set; }

    private string _typeConnect;

    public ApplicationDbContext(string typeConnect)
    {
        _typeConnect = typeConnect;
    }
    public ApplicationDbContext()
    {
        _typeConnect = "Migration";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile(Path.Combine("Data", "Configurations", "dbsettings.json"), optional: false)
                .Build();

            string? connectionString = configuration.GetConnectionString(_typeConnect);

            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
