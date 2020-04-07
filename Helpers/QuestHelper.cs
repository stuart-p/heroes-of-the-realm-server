using System;
using System.Collections.Generic;
using dotnetDating.api.Models;

namespace dotnetDating.api.Helpers
{
  public static class QuestHelper
  {
    private static Random rnd = new Random();
    private enum questType
    {
      explore, defend, rescue
    }
    private static List<string> exploreSeverity = new List<string>(){
    " a slightly damp ",
    " a very old ",
    " an abandoned ",
    " a haunted ",
    " a submerged ",
    " a burning "
    };
    private static List<string> exploreLocation = new List<string>(){
        "cupboard",
        "library",
        "house",
        "temple",
        "castle",
        "forest",
        "dungeon"
    };
    private static List<string> defendWhat = new List<string>(){
         " a small chest ",
         " a kitten ",
         " a farmer and their family ",
         " the village of Hovelton ",
         " the town of Seasonson ",
         " the city of WillowVale "
     };
    private static List<string> defendFrom = new List<string>(){
        "from marauding rabbits",
        "from unseasonal weather",
        "from bandits",
        "from ghosts",
        "from zombies",
        "from a dragon",
    };
    private static string genQuestTitle()
    {

      Array types = Enum.GetValues(typeof(questType));
      questType type = (questType)types.GetValue(rnd.Next(types.Length));

      switch (type)
      {
        case questType.defend:
          return ($"Defend{defendWhat[rnd.Next(defendWhat.Count)]}{defendFrom[rnd.Next(defendFrom.Count)]}");
        case questType.rescue:
          return ($"Rescue{defendWhat[rnd.Next(defendWhat.Count)]}{defendFrom[rnd.Next(defendFrom.Count)]}");
        case questType.explore:
          return ($"Explore{exploreSeverity[rnd.Next(exploreSeverity.Count)]}{exploreLocation[rnd.Next(exploreLocation.Count)]}");
        default:
          return "rescue nothing from nothing";
      }
    }

    private static int genQuestExperience()
    {
      return rnd.Next(1000);
    }

    private static long genQuestDuration(int Experience)
    {
      return Experience * 4;
    }

    public static Quest generateQuest()
    {
      var newQuest = new Quest();

      newQuest.Title = genQuestTitle();
      newQuest.Created = DateTime.Now;
      newQuest.isInProgress = false;
      newQuest.isComplete = false;
      newQuest.Experience = genQuestExperience();
      newQuest.Duration = genQuestDuration(newQuest.Experience);

      return newQuest;
    }
  }
}