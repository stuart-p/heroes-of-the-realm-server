using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnetDating.api.Data;
using dotnetDating.api.DTO;
using dotnetDating.api.Models;
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

    [HttpPatch("{id}/begin")]
    public async Task<IActionResult> BeginQuest(int id, [FromBody] BeginQuestRequestDTO patchDTO)
    {
      bool requestValid = await _repo.BeginQuest(id, patchDTO.UserID);

      if (requestValid)
      {
        return Accepted();
      }
      else return BadRequest("Only 1 quest at a time can be attempted");
    }

    [HttpPost("new")]
    public async Task<IActionResult> CreateNewQuest()
    {
      var currentQuests = await _repo.getActiveQuests();
      if (currentQuests.Count() <= 6)
      {
        bool attemptCreate = await _repo.CreateNewQuest();

        if (attemptCreate)
        {
          return Accepted();
        }
        else return BadRequest();
      }
      else return BadRequest();
    }

    [HttpPatch("{id}/complete")]
    public async Task<IActionResult> CompleteInProgressQuest(int id)
    {
      bool attemptComplete = await _repo.CompleteQuest(id);
      if (attemptComplete)
      {
        return Accepted();
      }
      else return BadRequest("Quest could not complete at this time");
    }
  }
}