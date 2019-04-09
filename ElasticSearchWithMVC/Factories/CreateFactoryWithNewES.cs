using System;
using System.Configuration;
using System.Web.Mvc;
using ElasticSearchWithMVC.Connector;
using ElasticSearchWithMVC.Models;
using Nest;

namespace ElasticSearchWithMVC.Factories
{
  public class CreateFactoryWithNewES : ICreateFactory
  {
    private readonly ElasticSearchConnection _connectionToEs;
    private readonly string _indexName;
    private readonly string _typeName;
    public CreateFactoryWithNewES()
    {
      _connectionToEs = new ElasticSearchConnection();
      _indexName = ConfigurationManager.AppSettings["ElasticSearchIndexName"];
      _typeName = ConfigurationManager.AppSettings["ElasticSearchTypeName"];
    }
    public JsonResult Build(Projectmaster model)
    {
      var response = _connectionToEs.ElasticSerchClient().Index(model, i => i
        .Index(_indexName)
        .Type(_typeName)
        .Id(Guid.NewGuid()));

      return new JsonResult
      {
        Data = GetJsonModel(response, model)
      };
    }
    private static object GetJsonModel(IIndexResponse response, Projectmaster model)
    {
      var result = new
      {
         props = new {
           model.projectname,
           model.NatureofIndustry,
           model.projectcode
         },
       msg = response.Result
      };
      return result;
    }
  }
}