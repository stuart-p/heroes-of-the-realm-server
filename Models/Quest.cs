using System;

namespace dotnetDating.api.Models
{
  public class Quest
  {
    public int Id { get; set; }

    public string Title { get; set; }

    public DateTime Created { get; set; }
    public bool isInProgress { get; set; }
    public bool isComplete { get; set; }

    public DateTime Completed { get; set; }

    public int Experience { get; set; }

    public long Duration { get; set; }

    public User AssignedUser { get; set; }
  }
}