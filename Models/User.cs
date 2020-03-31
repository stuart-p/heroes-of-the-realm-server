using System;
using System.Collections.Generic;

namespace dotnetDating.api.Models
{

  public enum CharacterClass
  {
    Bard,
    Barbarian,
    Druid,
    Cleric,
    Figher,
    Rogue,
    Wizard
  }
  public class User
  {
    public int Id { get; set; }

    public string Username { get; set; }

    public byte[] PasswordHash { get; set; }

    public byte[] PasswordSalt { get; set; }

    public string KnownAs { get; set; }

    public CharacterClass CharClass { get; set; }

    public DateTime LastActive { get; set; }

    public DateTime Created { get; set; }

    public int Level { get; set; }

    public int Experience { get; set; }

    public ICollection<Quest> Quests { get; set; }

    public Photo ProfilePicture { get; set; }

    public bool IsOnQuest { get; set; }
  }
}

// [
//   '{{repeat(5)}}',
//   {
//     Username: '{{firstName("female")}}',
//     Password: 'password',
//     KnownAs: function(){ return this.Username; },
//     Created: '{{date(new Date(2019,0,1), new Date(2019, 7, 31), "YYYY-MM-dd")}}',
//     LastActive: function() { return this.Created; },
//     Experience: '{{integer(1, 2000)}}',
//     Level: '{{integer(1,5)}}',
//     IsOnQuest: false,
//         CharClass: function(tags)
// {
//   var charClass = ['Barbarian', 'Fighter', 'Druid', 'Wizard', 'Cleric'];
//   return charClass[tags.integer(0, charClass.length - 1)];
// },
//     profilePicture: [
//         {
//           url: function(num) {
//           return 'https://randomuser.me/api/portraits/lego/' + num.integer(1, 9) + '.jpg';
//         }
//       }
//     ]
//   }
// ]