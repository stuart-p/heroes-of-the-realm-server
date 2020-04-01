using System.Collections.Generic;

namespace dotnetDating.api.Models
{
  public class Avatar
  {
    public int Id { get; set; }
    public string URL { get; set; }
    public virtual ICollection<User> Users { get; set; }
  }
}