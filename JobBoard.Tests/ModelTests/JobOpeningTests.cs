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

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      string description = "We are looking for a full-stack web developer.";
      JobOpening newJob = new JobOpening("test", description, "test");

      string result = newJob.Description;

      Assert.AreEqual(description, result);
    }

    [TestMethod]
    public void GetContact_ReturnsContact_String()
    {
      string contact = "abc@company.com";
      JobOpening newJob = new JobOpening("test", "test", contact);

      string result = newJob.Contact;

      Assert.AreEqual(contact, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfPropertiesAreTheSame_True()
    {
      JobOpening firstJob = new JobOpening("SDE", "Full Stack SDE", "abc@company.com");
      JobOpening secondJob = new JobOpening("SDE", "Full Stack SDE", "abc@company.com");

      Assert.AreEqual(firstJob, secondJob);
    }

    [TestMethod]
    public void Equals_ReturnsFalseIfPropertiesAreDifferent_False()
    {
      JobOpening firstJob = new JobOpening("SDE", "Full Stack SDE", "abc@company.com");
      JobOpening secondJob = new JobOpening("SDE", "Front End SDE", "abc@company.com");

      Assert.AreNotEqual(firstJob, secondJob);
    }
  }
}