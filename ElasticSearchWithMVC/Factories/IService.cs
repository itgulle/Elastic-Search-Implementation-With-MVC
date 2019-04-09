using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElasticSearchWithMVC.Factories
{
  public interface IService<t>
  {
    int Create(T t);
    IEnumerable<t> FindAll();
    T FindById(int id);
    void SendMail();
    void CalculateTotalProfit();
  }
}