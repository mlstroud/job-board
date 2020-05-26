using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace JobBoard.Controllers
{
  public class JobsController : Controller
  {
    [HttpGet("/jobs")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpPost("/jobs")]
    public ActionResult Create(string title, string description, string contact)
    {
      JobOpening newJob = new JobOpening(title, description, contact);
      newJob.Save();
      return RedirectToAction("Index");
    }

    [HttpGet("/jobs/new")]
    public ActionResult New()
    {
      return View();
    }
  }
}