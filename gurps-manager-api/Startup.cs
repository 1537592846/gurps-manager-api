using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace gurps_manager_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AddTransients(services);
            services.Configure<IISOptions>(options =>
                    options.AutomaticAuthentication = true);
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder => builder.WithOrigins("http://localhost:8100").AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());
            app.UseMvc();
        }

        public void AddTransients(IServiceCollection services)
        {
            var classList = Assembly.GetExecutingAssembly().GetTypes()
                 .Where(t => t.Namespace == "gurps_manager_library.DataAccess")
                 .ToList();

            foreach (var className in classList.Where(x => x.Name != "DataAccess" && x.Name.Contains("DataAccess")))
            {
                var type = Type.GetType("gurps_manager_library.DataAccess." + className.Name);
                services.AddTransient(type);
            }
        }
    }
}
