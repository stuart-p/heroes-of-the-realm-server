using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetDating.api.Models;
using Microsoft.EntityFrameworkCore;
using dotnetDating.api.Helpers;
using System.Diagnostics;

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
        var adventurer = await _context.Users.FirstOrDefaultAsync(User => User.Id == adventurerId);

        if (!adventurer.IsOnQuest)
        {
          DateTime startedTime = DateTime.Now;
          DateTime completionTime = DateTime.Now.AddSeconds((double)quest.Duration);

          quest.isInProgress = true;
          quest.Started = startedTime;
          quest.Completed = completionTime;
          quest.AssignedUser = adventurer;

          quest.AssignedUser.IsOnQuest = true;
          return await _context.SaveChangesAsync() > 0;
        }
        else return false;

      }
      else
      {
        return false;
      }
    }

    public async Task<bool> CompleteQuest(int id)
    {
      var quest = await _context.Quests.Include(quest => quest.AssignedUser).FirstOrDefaultAsync(quest => quest.Id == id);
      if (quest != null)
      {
        if (quest.Completed != null && quest.Completed <= DateTime.Now)
        {

          quest.isInProgress = false;
          quest.isComplete = true;

          quest.AssignedUser.IsOnQuest = false;
          quest.AssignedUser.Experience += quest.Experience;
          quest.AssignedUser.Level = QuestHelper.checkAdventurerLevel(quest.AssignedUser.Experience);

          return await _context.SaveChangesAsync() > 0;
        }
        else return false;

      }
      else
      {
        return false;
      }
    }

    public async Task<bool> CreateNewQuest()
    {
      var newQuest = QuestHelper.generateQuest();
      await _context.Quests.AddAsync(newQuest);

      return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<Quest>> getActiveQuests()
    {
      var quests = await _context.Quests.Where(quest => quest.isComplete == false).ToListAsync();

      return quests;
    }

    public async Task<IEnumerable<Quest>> getAdventurersQuests(int adventurerId)
    {
      var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == adventurerId);
      if (user != null)
      {

        var quests = user.Quests.ToList();
        return quests;
      }
      else return null;
    }

    public async Task<Quest> GetQuest(int id)
    {
      var quest = await _context.Quests.Include(quest => quest.AssignedUser).FirstOrDefaultAsync(quest => quest.Id == id);

      return quest;
    }

    public Task<IEnumerable<Quest>> getQuests()
    {
      throw new System.NotImplementedException();
    }
  }
}