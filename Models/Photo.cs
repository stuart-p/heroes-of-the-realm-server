namespace dotnetDating.api.Models
{
  public class Photo
  {
    public int Id { get; set; }
    public string URL { get; set; }
    public User user { get; set; }
    public int UserId { get; set; }
  }
}