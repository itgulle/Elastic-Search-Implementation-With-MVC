using System.Web.Mvc;
using ElasticSearchWithMVC.Connector;
using ElasticSearchWithMVC.Factories;
using ElasticSearchWithMVC.Models;

namespace ElasticSearchWithMVC.Controllers
{
  public class HomeController : Controller
  {
    private ICreateFactory _iCreateFactory;
    private ISearchFactory _iSearchFactory;

    public HomeController(ICreateFactory iCreateFactory, ISearchFactory iSearchFactory)
    {
      _iCreateFactory = iCreateFactory;
      _iSearchFactory = iSearchFactory;
    }
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }

    public JsonResult Search(string projectCode)
    {
      var result = _iSearchFactory.Build(projectCode);
      return result;
    }

    public JsonResult Create(string projectCode, string projectName, string natureofIndustry)
    {
      var model = new Projectmaster
      {
        projectname = projectName,
        NatureofIndustry = natureofIndustry,
        projectcode = projectCode
      };

      var result = _iCreateFactory.Build(model);
      return result;
    }
  }
}