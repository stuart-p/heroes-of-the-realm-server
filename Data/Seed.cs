using System.Collections.Generic;
using System.Linq;
using dotnetDating.api.Models;
using Newtonsoft.Json;

namespace dotnetDating.api.Data
{
  public class Seed
  {
    public static void SeedUsers(DataContext context)
    {
      if (!context.Users.Any())
      {
        var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
        var users = JsonConvert.DeserializeObject<List<User>>(userData);
        foreach (var user in users)
        {
          byte[] passwordHash, passwordSalt;
          createPasswordHash("password", out passwordHash, out passwordSalt);

          user.PasswordHash = passwordHash;
          user.PasswordSalt = passwordSalt;
          user.Username = user.Username.ToLower();

          context.Users.Add(user);

        }

        context.SaveChanges();
      }
    }

    public static void SeedQuests(DataContext context)
    {
      if (!context.Quests.Any())
      {
        var questData = System.IO.File.ReadAllText("Data/QuestSeedData.json");
        var quests = JsonConvert.DeserializeObject<List<Quest>>(questData);

        foreach (var quest in quests)
        {
          context.Quests.Add(quest);
        }

        context.SaveChanges();
      }
    }

    public static void SeedPhotos(DataContext context)
    {
      if (!context.Avatars.Any())
      {
        var AvatarData = System.IO.File.ReadAllText("Data/AvatarSeedData.json");
        var Avatars = JsonConvert.DeserializeObject<List<Avatar>>(AvatarData);

        foreach (var Avatar in Avatars)
        {
          context.Avatars.Add(Avatar);
        }

        context.SaveChanges();
      }
    }

    private static void createPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
      using (var hmac = new System.Security.Cryptography.HMACSHA512())
      {
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
      }
    }
  }
}