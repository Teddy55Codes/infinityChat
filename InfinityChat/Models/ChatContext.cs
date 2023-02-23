using Microsoft.EntityFrameworkCore;

namespace InfinityChat.Models;

public class ChatContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public ChatContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to mysql with connection string from app settings
        var connectionString = Configuration.GetConnectionString("WebApiDatabase");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
    
    public DbSet<ChatMessage> ChatMessages { get; set; }
}