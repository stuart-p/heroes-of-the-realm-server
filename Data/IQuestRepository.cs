using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetDating.api.Models;

namespace dotnetDating.api.Data
{
  public interface IQuestRepository
  {
    Task<IEnumerable<Quest>> getQuests();

    Task<IEnumerable<Quest>> getActiveQuests();

    Task<IEnumerable<Quest>> getAdventurersQuests(int adventurerId);

    Task<Quest> GetQuest(int id);

    Task<bool> CreateNewQuest();

    Task<bool> BeginQuest(int id, int adventurerId);

    Task<bool> CompleteQuest(int id);



  }
}