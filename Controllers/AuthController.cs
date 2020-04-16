using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using dotnetDating.api.Data;
using dotnetDating.api.DTO;
using dotnetDating.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace dotnetDating.api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly IAuthRepository _repo;
    private readonly IConfiguration _config;
    private readonly IAvatarRepository _avatarRepo;

    public AuthController(IAuthRepository repo, IConfiguration config, IAvatarRepository avatarRepo)
    {
      this._avatarRepo = avatarRepo;
      this._config = config;
      this._repo = repo;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserForRegisterDTO userForRegisterDTO)
    {
      //validate request

      userForRegisterDTO.Username = userForRegisterDTO.Username.ToLower();

      if (await _repo.UserExists(userForRegisterDTO.Username))
      {
        return BadRequest("Username already exists");
      }
      var defaultAvatar = await _avatarRepo.GetAvatar(1);
      var userToCreate = new User { Username = userForRegisterDTO.Username, KnownAs = userForRegisterDTO.Username, CharClass = CharacterClass.Barbarian, Created = DateTime.Now, LastActive = DateTime.Now, Avatar = defaultAvatar };
      var createdUser = await _repo.Register(userToCreate, userForRegisterDTO.Password);


      return StatusCode(201);
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login(UserForLoginDTO userForLoginDTO)
    {
      var userFromRepo = await _repo.Login(userForLoginDTO.Username.ToLower(), userForLoginDTO.Password);

      if (userFromRepo == null)
      {
        return Unauthorized();
      }

      var claims = new[] {
        new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
        new Claim(ClaimTypes.Name, userFromRepo.Username)
      };

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.Now.AddDays(1),
        SigningCredentials = creds
      };

      var tokenHandler = new JwtSecurityTokenHandler();

      var token = tokenHandler.CreateToken(tokenDescriptor);

      return Ok(new
      {
        token = tokenHandler.WriteToken(token),
        timeStamp = DateTime.Now
      });
    }
  }
}