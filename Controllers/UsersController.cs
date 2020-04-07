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
  public class UsersController : ControllerBase
  {
    private readonly IUserRepository _repo;
    private readonly IMapper _mapper;
    private readonly IQuestRepository _questRepo;

    public UsersController(IUserRepository repo, IMapper mapper, IQuestRepository questRepo)
    {
      this._questRepo = questRepo;
      this._mapper = mapper;
      this._repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
      var users = await _repo.GetUsers();

      var usersToReturn = _mapper.Map<IEnumerable<UserForListDTO>>(users);
      return Ok(usersToReturn);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
      var user = await _repo.GetUser(id);


      var userToReturn = _mapper.Map<UserForDetailedDTO>(user);
      return Ok(userToReturn);
    }

    [HttpGet("{id}/quests")]
    public async Task<IActionResult> GetUsersQuests(int id)
    {
      var quests = await _questRepo.getAdventurersQuests(id);

      return Ok(quests);
    }
  }
}