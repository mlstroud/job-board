using Microsoft.AspNetCore.Mvc;

namespace JobBoard.Controllers
{
  public class JobsController : Controller
  {
    [HttpGet("/jobs")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet("/jobs/new")]
    public ActionResult New()
    {
      return View();
    }
  }
}