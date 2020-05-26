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

    public override bool Equals(System.Object otherJob)
    {
      if (!(otherJob is JobOpening))
      {
        return false;
      }
      else
      {
        JobOpening newJob = (JobOpening)otherJob;
        bool titleEquality = (this.Title == newJob.Title);
        bool descriptionEquality = (this.Description == newJob.Description);
        bool contactEquality = (this.Contact == newJob.Contact);
        return (titleEquality && descriptionEquality && contactEquality);
      }
    }
  }
}