using CaseStudyServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using MuratSekerCaseStudy.Services;
using System.IO;

namespace MuratSekerCaseStudy
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<CaseStudyContext>(options => options.UseSqlServer(
            //    Configuration["Data:CaseStudyConnection:ConnectionString"]));
            services.AddSingleton<IFileProvider>(
                new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploadedfiles")));

            services.AddTransient<IReadFileService, ReadCsvFileService>();
            services.AddTransient<IFileWriter, WriteJsonFileService>();
            services.AddTransient<IFileWriter, WriteXmlFileService>();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc(cfg =>
            {
                cfg.MapRoute("Default",
                    "/{controller}/{action}/{id?}",
                    new {controller = "Home", Action = "Index"});
            });
        }
    }
}
