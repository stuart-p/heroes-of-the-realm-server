using Microsoft.EntityFrameworkCore;
using dotnetDating.api.Models;

namespace dotnetDating.api.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Value> Values { get; set; }
  }
}