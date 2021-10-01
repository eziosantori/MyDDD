using Autofac;
using Microsoft.Extensions.Configuration;
using MyDDD.API.Repository;
using MyDDD.Domain.Core;
using MyDDD.Domain.Macchine.Repository;
using MyDDD.Infrastucture.Domain;

namespace MyDDD.Infrastucture
{
  public class MyDDDModule : Module
  {
    private readonly IConfiguration _configuration;
    public MyDDDModule(IConfiguration configuration)
    {
      _configuration = configuration;
    }
    protected override void Load(ContainerBuilder builder)
    {

      builder.RegisterType<UnitOfWork>()
          .As<IUnitOfWork>()
          .WithParameter("configuration", _configuration)
          .InstancePerLifetimeScope();

      builder.RegisterType<MacchineRepository>()
          .As<IMacchineRepository>()
          .InstancePerLifetimeScope();
    }
  }
}
