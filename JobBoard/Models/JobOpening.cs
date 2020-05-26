using System.Collections.Generic;
using MySqlConnection;

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

    public void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM job_openings;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public List<JobOpening> GetAll()
    {
      List<JobOpening> allJobs = new List<JobOpening>();
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand = conn.CreateCommand() as MySqlConnection;
      cmd.CommandText = @"SELECT * FROM job_openings";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int jobId = rdr.GetInt32(0);
        string jobTitle = rdr.GetString(1);
        string jobDescription = rdr.GetString(2);
        string jobContact = rdr.GetString(3);

        JobOpening job = new JobOpening(jobTitle, jobDescription, jobContact, jobId);
        allJobs.Add(job);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}