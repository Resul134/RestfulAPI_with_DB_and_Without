using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace ClassDemoRestService
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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://example.com"));
                options.AddPolicy("AllowAnyOrigin",
                    builder => builder.AllowAnyOrigin());
                options.AddPolicy("AllowAnyOriginGetPost",
                    builder => builder.AllowAnyOrigin().WithMethods("GET",
                        "POST"));
            });



            //services.AddSwaggerGen(c 
            //    => c.SwaggerDoc("v1", new Info(){Title = "Cars API", Version = "v1.0"}) );
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(
                options =>
                {
                    options.AllowAnyOrigin().
                        AllowAnyHeader().
                        WithMethods("GET", "POST", "PUT" , "DELETE");
                    // allow everything from anywhere
                });


            //app.UseSwagger();
            //app.UseSwaggerUI(
            //    c =>
            //    {
            //        c.SwaggerEndpoint("/swagger/v1/swagger.json",
            //            "Cars API v1.0");
            //        c.RoutePrefix = "api/help";
            //    });

            
            app.UseMvc();
        }
    }
}
