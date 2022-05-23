using System.IO;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Buffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore;
using sistemaAcad.Data;
using Microsoft.EntityFrameworkCore;


namespace sistemaAcad
{
    public class Startup
    {
        public IConfiguration Configuration {get;}

        public Startup(IConfiguration configuration){
            Configuration = configuration;
        }
        // -----------------------------------------
        public void ConfigureServices(IServiceCollection services) {
            
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddDbContext<DataSysContext>(options => options.UseSqlite(Configuration.GetConnectionString("DataSysContext")));
        }

        // -------------------------------------------
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
