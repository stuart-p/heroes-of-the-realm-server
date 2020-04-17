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
      int firstAvatar = 1;
      int lastAvatar = await _context.Avatars.CountAsync();
      if (id < firstAvatar) id = lastAvatar;
      if (id > lastAvatar) id = firstAvatar;
      var avatar = await _context.Avatars.FirstOrDefaultAsync(av => av.Id == id);

      return avatar;
    }
    public async Task<Avatar> GetAvatarByURL(string url)
    {
      var avatar = await _context.Avatars.FirstOrDefaultAsync(av => av.URL == url);

      return avatar;
    }

    public async Task<Avatar> GetSequenceAvatarByURL(string url, bool isNext)
    {
      var currentAvatar = await _context.Avatars.FirstOrDefaultAsync(av => av.URL == url);
      int desiredAvatarID = 1;
      if (currentAvatar != null)
      {
        desiredAvatarID = isNext ? currentAvatar.Id + 1 : currentAvatar.Id - 1;
      }
      var desiredAvatar = await GetAvatar(desiredAvatarID);

      return desiredAvatar;
    }

    public async Task<IEnumerable<Avatar>> getAvatars()
    {
      var avatars = await _context.Avatars.ToListAsync();

      return avatars;
    }
  }
}