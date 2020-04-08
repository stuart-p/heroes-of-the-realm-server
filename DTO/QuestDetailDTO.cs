using System;

namespace dotnetDating.api.DTO
{
  public class QuestDetailDTO
  {
    public int Id { get; set; }

    public string Title { get; set; }

    public DateTime Created { get; set; }
    public bool isInProgress { get; set; }
    public bool isComplete { get; set; }

    public DateTime? Started { get; set; }
    public DateTime? Completed { get; set; }

    public int Experience { get; set; }

    public long Duration { get; set; }

    public string AssignedUser { get; set; }
  }
}