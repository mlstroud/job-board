namespace JobBoard.Models
{
  public class JobOpening
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public string Contact { get; set; }
    public int Id { get; set; }

    public JobOpening(string title, string description, string contact)
    {
      Title = title;
      Description = description;
      Contact = contact;
    }

    public JobOpening(string title, string description, string contact, int id)
    {
      Title = title;
      Description = description;
      Contact = contact;
      Id = id;
    }
  }
}