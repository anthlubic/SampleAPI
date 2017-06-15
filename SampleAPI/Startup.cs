using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SampleAPI.Persistence.Inventory;

namespace SampleAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<InventoryContext>(o =>
            {
                o.UseInMemoryDatabase(Configuration.GetConnectionString("InventoryDb"));
            });

            services.AddCors();
            services.AddMediatR(typeof(Startup), typeof(Services.Registry.ServicesStructureMapRegistry));

            // Add framework services.
            services.AddMvc()
                .AddControllersAsServices();

            //return ConfigureIoC(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

        }

        //public IServiceProvider ConfigureIoC(IServiceCollection services)
        //{
        //    var container = new Container();

        //    container.Configure(config =>
        //    {
        //        // Register stuff in container, using the StructureMap APIs...
        //        config.Scan(_ =>
        //        {
        //            _.AssembliesFromApplicationBaseDirectory();
        //            _.WithDefaultConventions();
        //            _.LookForRegistries();
        //        });

        //        config.For<IMediator>().Use<Mediator>();
        //        config.For<SingleInstanceFactory>().Use<SingleInstanceFactory>(ctx => t => ctx.GetInstance(t));
        //        config.For<MultiInstanceFactory>().Use<MultiInstanceFactory>(ctx => t => ctx.GetAllInstances(t));
        //        //Populate the container using the service collection
        //        config.Populate(services);
        //    });

        //    return container.GetInstance<IServiceProvider>();

        //}
    }
}
