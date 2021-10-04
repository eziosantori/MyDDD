using Autofac;
using Microsoft.Extensions.Configuration;
using MyDDD.API.Repository;
using MyDDD.Domain.Core;
using MyDDD.Domain.Macchine.Repository;
using MyDDD.Infrastucture.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDDD.Infrastucture.Modules
{
  public class DataAccessModule : Module
  {
    private readonly IConfiguration _configuration;
    public DataAccessModule(IConfiguration configuration)
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
