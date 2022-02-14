using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Store.Core.Interfaces;
using Store.Infrastructure.Data;
using Store.Infrastructure.Data.Repositories;
using Store.Web.Interfaces;
using Store.Web.Services;
using Store.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Hotel.Infrastructure.Security;
using Store.Infrastructure.FileSystem;

namespace Store.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StoreDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("StoreDataBase")));

            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            services.AddScoped<IPasswordHasher, PasswordHasher>();

            services.AddScoped<IFileStorage>(provider => new FileStorage(Environment.WebRootPath));
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISupportService, SupportService>();

            services.AddScoped<IGameViewModelService, GameViewModelService>();
            services.AddScoped<ISupportViewModelService, SupportViewModelService>();
            services.AddScoped<IUserViewModelService, UserViewModelService>();

            services.AddControllersWithViews();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/Account/Index");
                    options.AccessDeniedPath = new PathString("/Account/Index");
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
