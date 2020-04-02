using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetDating.api.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetDating.api.Data
{
  public class QuestRepository : IQuestRepository
  {
    private readonly DataContext _context;
    public QuestRepository(DataContext context)
    {
      this._context = context;

    }
    public async Task<bool> BeginQuest(int id, int adventurerId)
    {
      var quest = await _context.Quests.FirstOrDefaultAsync(quest => quest.Id == id);
      if (quest != null)
      {
        DateTime now = DateTime.Now;
        now.AddSeconds((double)quest.Duration);

        quest.isInProgress = true;
        quest.Completed = now;

        return await _context.SaveChangesAsync() > 0;
      }
      else
      {
        return false;
      }
    }

    public Task<bool> CompleteQuest(int id)
    {
      throw new System.NotImplementedException();
    }

    public Task<bool> CreateNewQuest()
    {
      throw new System.NotImplementedException();
    }

    public async Task<IEnumerable<Quest>> getActiveQuests()
    {
      var quests = await _context.Quests.Where(quest => quest.isComplete == false).ToListAsync();

      return quests;
    }

    public Task<IEnumerable<Quest>> getAdventurersQuests(int adventurerId)
    {
      throw new System.NotImplementedException();
    }

    public Task<Quest> GetQuest(int id)
    {
      throw new System.NotImplementedException();
    }

    public Task<IEnumerable<Quest>> getQuests()
    {
      throw new System.NotImplementedException();
    }
  }
}