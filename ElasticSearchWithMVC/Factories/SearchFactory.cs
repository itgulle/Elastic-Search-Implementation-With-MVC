using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using ElasticSearchWithMVC.Connector;
using ElasticSearchWithMVC.Models;
using Nest;

namespace ElasticSearchWithMVC.Factories
{
  public class SearchFactory : ISearchFactory
  {
    private readonly ElasticSearchConnection _connectionToEs;
    private readonly string _indexName;
    private readonly string _typeName;
    public SearchFactory()
    {
      _connectionToEs = new ElasticSearchConnection();
      _indexName = ConfigurationManager.AppSettings["ElasticSearchIndexName"];
      _typeName = ConfigurationManager.AppSettings["ElasticSearchTypeName"];
    }
    public JsonResult Build(string projectCode)
    {
      var responsedata = _connectionToEs.ElasticSerchClient().Search<Projectmaster>(s => s
        .Index(_indexName)
        .Type(_typeName)
        .Size(50)
        .Query(q => q
          .Match(m => m
            .Field(f => f.projectcode)
            .Query(projectCode)
          )
        )
      );

      var data = (from hits in responsedata.Hits
        select hits.Source).ToList();
      data.Insert(0, new Projectmaster
      {
        projectname = "Project Name",
        projectcode = "Project Code",
        NatureofIndustry = "Nature of Industory"
      });

      return new JsonResult
      {
        Data = GetJsonModel(data)
      };
    }
    private static object GetJsonModel(List<Projectmaster> data)
    {
      var result = new
      {
        props = new {
          data
        }
      };
      return result;
    }
  }
}