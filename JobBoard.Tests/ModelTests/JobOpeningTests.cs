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
      JobOpening newJob = new JobOpening();

      Assert.AreEqual(typeof(JobOpening), newJob.GetType());
    }
  }
}