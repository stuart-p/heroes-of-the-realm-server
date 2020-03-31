using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetDating.api.Models;

namespace dotnetDating.api.Data
{
  public interface IUserRepository
  {
    void Add<T>(T entity) where T : class;
    void Delete<T>(T entity) where T : class;
    Task<bool> SaveAll();
    Task<IEnumerable<User>> GetUsers();

    Task<User> GetUser(int id);
  }
}