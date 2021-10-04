using Autofac;
using Microsoft.Extensions.Configuration;
using MyDDD.API.Repository;
using MyDDD.Domain.Core;
using MyDDD.Domain.Macchine.Repository;
using MyDDD.Infrastucture.Domain;
using MyDDD.Infrastucture.Modules;

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

        builder.RegisterModule(new DataAccessModule(_configuration));
        builder.RegisterModule(new MediatorModule());
    }
  }
}
