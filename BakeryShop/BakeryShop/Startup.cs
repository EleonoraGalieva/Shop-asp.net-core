using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Domain.Interfaces;
using Infrastructure.Data;
using Services.BusinessLogic;
using System;
using Domain.Core;

namespace BakeryShop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                m => m.MigrationsAssembly("BakeryShop")));
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedEmail = true;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    /*options.ClientId = Configuration["Authentication:ClientId"];
                    options.ClientSecret = Configuration["Authentication:ClientSecret"];*/
                    options.ClientId = "668642207552-f58kbrjt2vjtn1b7td8pitubjjltujn3.apps.googleusercontent.com";
                    options.ClientSecret = "QD9ng15VEhZPjYiXFvdgvvO3";
                });
            services.AddScoped<IPieRepository, PieRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ShoppingCart>(sp=>new ShoppingCart(sp).Cart);
            services.AddHttpContextAccessor();
            services.AddSession();
            services.AddControllersWithViews();
            services.AddSignalR();
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
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithRedirects("/Error/{0}");
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();
            app.UseSerilogRequestLogging();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<CommentHub>("/commentHub");
            });
        }
    }
}
