using Autofac;
using Autofac.Core;
using Autofac.Features.Variance;
using MediatR;
using MyDDD.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyDDD.Infrastucture.Modules
{
  public class MediatorModule : Autofac.Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
    .RegisterType<Mediator>()
    .As<IMediator>()
    .InstancePerLifetimeScope();

      // request & notification handlers
      builder.Register<ServiceFactory>(context =>
      {
        var c = context.Resolve<IComponentContext>();
        return t => c.Resolve(t);
      });

      // finally register our custom code (individually, or via assembly scanning)
      // - requests & handlers as transient, i.e. InstancePerDependency()
      // - pre/post-processors as scoped/per-request, i.e. InstancePerLifetimeScope()
      // - behaviors as transient, i.e. InstancePerDependency()
      builder
        .RegisterAssemblyTypes(typeof(CommandBase).GetTypeInfo().Assembly)
        .AsImplementedInterfaces(); // via assembly scan
                                                                                                      //builder.RegisterType<MyHandler>().AsImplementedInterfaces().InstancePerDependency();          // or individually

      // builder.RegisterGeneric(typeof(CommandValidationBehavior<,>)).As(typeof(IPipelineBehavior<,>));
    }

   
  }

}
