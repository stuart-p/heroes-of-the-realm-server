using System.ComponentModel.DataAnnotations;

namespace dotnetDating.api.DTO
{
  public class UserForRegisterDTO
  {
    [Required]
    public string Username { get; set; }
    [Required]
    [StringLength(32, MinimumLength = 4, ErrorMessage = "Password must be greater than 4 characters in length")]
    public string Password { get; set; }

  }
}