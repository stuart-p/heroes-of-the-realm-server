using System.Threading.Tasks;
using dotnetDating.api.Models;

namespace dotnetDating.api.Data
{
  public interface IAuthRepository
  {
    Task<User> Register(User user, string password);

    Task<User> Login(string username, string password);

    Task<bool> UserExists(string username);
  }
}