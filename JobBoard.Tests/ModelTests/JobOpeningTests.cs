using Microsoft.VisualStudio.TestTools.UnitTesting;
using JobBoard.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace JobBoard.Tests
{
  [TestClass]
  public class JobOpeningTests
  {
    public JobOpeningTests()
    {
      DBConfiguration.ConnectionString = "sever=localhost;user id=root;password=epicodus;port=3306;database=job_board_test;";
    }

    [TestMethod]
    public void JobOpeningConstructor_CreatesInstanceOfJobOpening_JobOpening()
    {
      JobOpening newJob = new JobOpening("test", "test", "test");

      Assert.AreEqual(typeof(JobOpening), newJob.GetType());
    }

    [TestMethod]
    public void GetTitle_ReturnsTitle_String()
    {
      string title = "Software Developer";
      JobOpening newJob = new JobOpening(title, "test", "test");

      string result = newJob.Title;

      Assert.AreEqual(title, result);
    }
  }
}