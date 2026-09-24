using Microsoft.EntityFrameworkCore;
using DotNetMessenger.Domain.Entities;

namespace DotNetMessenger.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Chat> Chats { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<User> Users { get; set; }
}
