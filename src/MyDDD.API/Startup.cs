using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MyDDD.API.Repository;
using MyDDD.Domain.Core;
using MyDDD.Domain.Macchine.Repository;
using MyDDD.Infrastucture;
using MyDDD.Infrastucture.Domain;

namespace MyDDD.API
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    public ILifetimeScope AutofacContainer { get; private set; }
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      // todo... finire in unautofac buyilder
      // services.RegisterMyDDDModule(Configuration);
      //services.AddScoped<IUnitOfWork, UnitOfWork>();
      //services.AddScoped<IMacchineRepository, MacchineRepository>();

      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyDDD.API", Version = "v1" });
      });
    }
    // ConfigureContainer is where you can register things directly
    // with Autofac. This runs after ConfigureServices so the things
    // here will override registrations made in ConfigureServices.
    // Don't build the container; that gets done for you by the factory.
    public void ConfigureContainer(ContainerBuilder builder)
    {
      // Register your own things directly with Autofac here. Don't
      // call builder.Populate(), that happens in AutofacServiceProviderFactory
      // for you.
      builder.RegisterModule(new MyDDDModule(Configuration));
    }
    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      // If, for some reason, you need a reference to the built container, you
      // can use the convenience extension method GetAutofacRoot.
      this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();

    // AUTH JWT
    // https://www.c-sharpcorner.com/article/asp-net-web-api-2-creating-and-validating-jwt-json-web-token/
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyDDD.API v1"));
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
