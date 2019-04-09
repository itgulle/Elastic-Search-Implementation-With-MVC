using Autofac;
using ElasticSearchWithMVC.Factories;

namespace ElasticSearchWithMVC
{
  public class DataModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<CreateFactoryWithNewES>().As<ICreateFactory>().InstancePerRequest();
      builder.RegisterType<SearchFactory>().As<ISearchFactory>().InstancePerRequest();

      base.Load(builder);
    }
  }
}