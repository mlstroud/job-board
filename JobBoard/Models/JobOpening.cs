using System.Collections.Generic;
using MySql.Data.MySqlClient;

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

    public static void ClearAll()
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

    public static List<JobOpening> GetAll()
    {
      List<JobOpening> allJobs = new List<JobOpening>();
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
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

      return allJobs;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO job_openings (title, description, contact) VALUES (@jobTitle, @jobDescription, @jobContact);";
      MySqlParameter title = new MySqlParameter();
      title.ParameterName = "@jobTitle";
      title.Value = this.Title;
      MySqlParameter description = new MySqlParameter();
      description.ParameterName = "@jobDescription";
      description.Value = this.Description;
      MySqlParameter contact = new MySqlParameter();
      contact.ParameterName = "@jobContact";
      contact.Value = this.Contact;
      cmd.Parameters.Add(title);
      cmd.Parameters.Add(description);
      cmd.Parameters.Add(contact);
      cmd.ExecuteNonQuery();
      Id = (int)cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}