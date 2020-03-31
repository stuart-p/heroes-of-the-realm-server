using System;
using System.Collections.Generic;
using dotnetDating.api.Models;

namespace dotnetDating.api.DTO
{
  public class UserForDetailedDTO
  {
    public int Id { get; set; }

    public string Username { get; set; }

    public string KnownAs { get; set; }

    public CharacterClass CharClass { get; set; }

    public DateTime LastActive { get; set; }

    public DateTime Created { get; set; }

    public int Level { get; set; }

    public int Experience { get; set; }

    public ICollection<Quest> Quests { get; set; }

    public string PhotoURL { get; set; }

    public bool IsOnQuest { get; set; }
  }
}