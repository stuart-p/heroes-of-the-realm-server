using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetDating.api.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetDating.api.Data
{
  public class AvatarRepository : IAvatarRepository
  {
    private readonly DataContext _context;

    public AvatarRepository(DataContext context)
    {
      this._context = context;

    }
    public async Task<Avatar> GetAvatar(int id)
    {
      var avatar = await _context.Avatars.FirstOrDefaultAsync(av => av.Id == id);

      return avatar;
    }

    public async Task<IEnumerable<Avatar>> getAvatars()
    {
      var avatars = await _context.Avatars.ToListAsync();

      return avatars;
    }
  }
}