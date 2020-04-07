using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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
    private readonly IMapper _mapper;
    public QuestController(IQuestRepository repo, IMapper mapper)
    {
      this._mapper = mapper;
      this._repo = repo;

    }

    [HttpGet("active")]
    public async Task<IActionResult> getActiveQuests()
    {
      var quests = await _repo.getActiveQuests();

      return Ok(quests);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> getQuest(int id)
    {
      var quest = await _repo.GetQuest(id);
      var questToReturn = _mapper.Map<QuestDetailDTO>(quest);
      return Ok(questToReturn);
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