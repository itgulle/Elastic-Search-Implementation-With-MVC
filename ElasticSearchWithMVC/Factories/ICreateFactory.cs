using System.Web.Mvc;
using ElasticSearchWithMVC.Models;

namespace ElasticSearchWithMVC.Factories
{
  public interface ICreateFactory
  {
    JsonResult Build(Projectmaster model);
  }
}