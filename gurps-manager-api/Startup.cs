using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using gurps_manager_library.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => { builder.AllowAnyOrigin(); });
            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Shows UseCors with named policy.
            app.UseCors("AllowSpecificOrigin");
            
            app.UseMvc();
        }

        public void AddTransients(IServiceCollection services)
        {
            var classList = Assembly.GetExecutingAssembly().GetTypes()
                 .Where(t => t.Namespace == "gurps_manager_library.DataAccess")
                 .ToList();

            foreach (var className in classList.Where(x => x.Name != "DataAccess"))
            {
                var type = Type.GetType("gurps_manager_library.DataAccess." + className.Name);
                services.AddTransient(type);
            }
        }
    }
}
