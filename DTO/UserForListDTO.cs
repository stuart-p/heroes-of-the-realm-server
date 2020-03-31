using System;
using System.Collections.Generic;
using dotnetDating.api.Models;

namespace dotnetDating.api.DTO
{
  public class UserForListDTO
  {
    public int Id { get; set; }

    public string Username { get; set; }

    public string KnownAs { get; set; }

    public CharacterClass CharClass { get; set; }

    public int Level { get; set; }

    public string PhotoURL { get; set; }

  }
}