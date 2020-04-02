using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetDating.api.Models;

namespace dotnetDating.api.Data
{
  public interface IAvatarRepository
  {
    Task<IEnumerable<Avatar>> getAvatars();

    Task<Avatar> GetAvatar(int id);
  }
}