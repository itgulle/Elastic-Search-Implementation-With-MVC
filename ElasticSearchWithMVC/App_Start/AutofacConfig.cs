using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace ElasticSearchWithMVC.App_Start
{
  public class AutofacConfig
  {
    public static void ConfigureContainer()
    {
      var builder = new ContainerBuilder();
      builder.RegisterControllers(typeof(MvcApplication).Assembly);
      builder.RegisterFilterProvider();
      builder.RegisterSource(new ViewRegistrationSource());
      builder.RegisterModule(new DataModule());
      var container = builder.Build();

      DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
    }
  }
}