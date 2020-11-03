using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaterialManagement_Web_DLL.infra;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MaterialManagement_Web_App
{
    
    public class Startup
    {
          readonly string MyAllowSpecificOrigins = "AllowAll";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<ApplicationDbContext>(options=>
            {
                 options.UseNpgsql("Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=envision1!;Timeout=300;CommandTimeout=300", b => b.MigrationsAssembly("MaterialManagement_Web_App")); 
            });
            services.AddCors(opts=>
            {
                opts.AddPolicy(name:MyAllowSpecificOrigins,builder=>
                {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
