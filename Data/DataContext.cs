using Microsoft.EntityFrameworkCore;
using dotnetDating.api.Models;

namespace dotnetDating.api.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Value> Values { get; set; }
    public DbSet<User> Users { get; set; }

    public DbSet<Avatar> Avatars { get; set; }
    public DbSet<Quest> Quests { get; set; }
  }
}