using System.Threading.Tasks;
using dotnetDating.api.Data;
using dotnetDating.api.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnetDating.api.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class QuestController : ControllerBase
  {
    private readonly IQuestRepository _repo;
    public QuestController(IQuestRepository repo)
    {
      this._repo = repo;

    }

    [HttpGet("active")]
    public async Task<IActionResult> getActiveQuests()
    {
      var quests = await _repo.getActiveQuests();

      return Ok(quests);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> BeginQuest(int id, [FromBody] BeginQuestRequestDTO patchDTO)
    {
      bool requestValid = await _repo.BeginQuest(id, patchDTO.UserID);

      if (requestValid)
      {
        return Accepted();
      }
      else return Unauthorized();
    }
  }
}