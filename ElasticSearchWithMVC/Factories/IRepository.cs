using System.Collections.Generic;

namespace ElasticSearchWithMVC.Factories
{
  public interface IRepository<t>
  {
    int Create(T t);
    IEnumerable<t> FindAll();
    T FindById(int id);
  }

  public class T
  {
  }
}