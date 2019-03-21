using System;
using Elasticsearch.Net;
using Nest;

namespace ElasticSearchWithMVC.Connector
{
  public class ElasticSearchConnection
  {
    public ElasticClient ElasticSerchClient()
    {
      var nodes = new Uri[]
      {
        new Uri("http://127.0.0.1:9200/")
      };

      var connectionPool = new StaticConnectionPool(nodes);
      var connectionSettings = new ConnectionSettings(connectionPool).DisableDirectStreaming();
      var elasticClient = new ElasticClient(connectionSettings);

      return elasticClient;
    }

  }
}