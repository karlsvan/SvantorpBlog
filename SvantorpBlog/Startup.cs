using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.Web.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SvantorpBlog.Features.AdminRegister;

namespace SvantorpBlog
{
    public class Startup
    {

        private readonly IWebHostEnvironment _webHostingEnvironment;
        private readonly IConfiguration _configuration;

        public Startup(IWebHostEnvironment webHostingEnvironment, IConfiguration configuration)
        {
            _webHostingEnvironment = webHostingEnvironment;
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCmsAspNetIdentity<ApplicationUser>();
            services.AddMvc();
            services.AddSession();
            services.AddRazorPages(o =>
            {
                o.RootDirectory = "/Features";
            });

            services.Configure<RazorViewEngineOptions>(o =>
            {                
                //o.ViewLocationExpanders.Add(new FeatureViewLocationExpander());
            });
            services.AddCms();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseMiddleware<AdministratorRegistrationPageMiddleware>();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapContent();
                endpoints.MapControllers();
                endpoints.MapControllerRoute("Register", "/Register", new { controller = "Register", action = "Index" });
                endpoints.MapRazorPages();
            });

        }
    }
}
