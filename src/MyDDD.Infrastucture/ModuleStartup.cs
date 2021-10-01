using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MyDDD.Infrastucture
{
  public static class ModuleStartup
  {
    public static IServiceCollection RegisterMyDDDModule(this IServiceCollection services, IConfiguration configuration)
    {
      var container = new ContainerBuilder();
      container.Populate(services);
      container.RegisterModule(new MyDDDModule(configuration));

      return services;
    }
  }
}
