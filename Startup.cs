using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using myfirstnetcoreapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myfirstnetcoreapp
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
            //services.AddRazorPages();
           // services.AddMvcCore();//everytime we are clicking on create we are issueing new http request
           services.AddMvc(options =>
           {
               options.EnableEndpointRouting = false;
               var policy = new AuthorizationPolicyBuilder()
                   .RequireAuthenticatedUser()
                   .Build();
               options.Filters.Add(new AuthorizeFilter(policy));

           });
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

            services.AddDbContextPool<AppDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("EmployeeDbConnection"))
                );
            services.Configure<IdentityOptions>(options => {
                options.Password.RequiredLength = 10;
                options.Password.RequireNonAlphanumeric = false;

               } ) ;
            services.AddScoped<IManageEmployeeDB, ManageEmployeeDB>();

        }
            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())     
            {
                app.UseDeveloperExceptionPage();
                app.UseAuthentication();
            }
            else
            {
                //  app.UseStatusCodePages();
                app.UseAuthentication();
                app.UseExceptionHandler("/Error/Error");
               app.UseStatusCodePagesWithReExecute("/Error/HttpStatusCodeHandler/{0}");
               


            }

            app.UseStaticFiles();
           // app.UseRouting();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapRoute("default", "{controller=Home}/{action=Index}");
            //});


            // app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
            //  app.UseMvc();
            

            //   app.Run(async (context) =>
            // await context.Response.WriteAsync("Response received  from Environment " + env.EnvironmentName)
            //app.UseDefaultFiles();



        }
    }
}








