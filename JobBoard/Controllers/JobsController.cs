using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using JobBoard.Models;
using System.Collections.Generic;

namespace JobBoard.Controllers
{
  public class JobsController : Controller
  {
    [HttpGet("/jobs")]
    public ActionResult Index()
    {
      List<JobOpening> allJobs = JobOpening.GetAll();
      return View(allJobs);
    }

    [HttpPost("/jobs")]
    public ActionResult Create(string title, string description, string contact)
    {
      JobOpening newJob = new JobOpening(title, description, contact);
      newJob.Save();
      return RedirectToAction("Index");
    }

    [HttpGet("/jobs/{id}")]
    public ActionResult Show(int id)
    {
      JobOpening job = JobOpening.Find(id);
      return View(job);
    }

    [HttpGet("/jobs/new")]
    public ActionResult New()
    {
      return View();
    }
  }
}