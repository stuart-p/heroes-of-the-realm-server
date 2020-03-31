using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetDating.api.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetDating.api.Data
{
  public class UserRepository : IUserRepository
  {
    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
      this._context = context;
    }
    public void Add<T>(T entity) where T : class
    {
      _context.Add(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
      _context.Remove(entity);
    }

    public async Task<User> GetUser(int id)
    {
      var user = await _context.Users.Include(p => p.ProfilePicture).Include(q => q.Quests).FirstOrDefaultAsync(u => u.Id == id);

      return user;
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
      var users = await _context.Users.Include(p => p.ProfilePicture).ToListAsync();

      return users;
    }

    public async Task<bool> SaveAll()
    {
      return await _context.SaveChangesAsync() > 0;
    }
  }
}