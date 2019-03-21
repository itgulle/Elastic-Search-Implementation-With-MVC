using System.Web.Mvc;

namespace ElasticSearchWithMVC.Factories
{
  public interface ISearchFactory
  {
    JsonResult Build(string projectCode);
  }
}