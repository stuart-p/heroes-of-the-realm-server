using System.Threading.Tasks;
using dotnetDating.api.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnetDating.api.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class AvatarController : ControllerBase
  {
    private readonly IAvatarRepository _repo;
    public AvatarController(IAvatarRepository repo)
    {
      this._repo = repo;

    }

    [HttpGet]
    public async Task<IActionResult> getAvatars()
    {
      var avatars = await _repo.getAvatars();

      return Ok(avatars);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> getAvatar(int id)
    {
      var avatar = await _repo.GetAvatar(id);

      return Ok(avatar);
    }
  }
}