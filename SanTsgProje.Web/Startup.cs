using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SanTsgProje.Application.Interfaces;
using SanTsgProje.Application.Services;
using SanTsgProje.Data;
using SanTsgProje.Data.Repositories;
using SanTsgProje.Data.Repositories.Interfaces;
using SanTsgProje.Shared.SettingsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SanTsgProje.Web
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
            
            services.AddControllersWithViews();
            services.AddDbContext<ProjeDbContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //Email Settings and Email Service
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.AddScoped<IEmailService, EmailService>();
            // Unit Of work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //User Service
            services.AddTransient<IUserService, UserService>();
            //Hotel Service
            services.AddTransient<ISearchingService, SearchingService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IPriceSearchingService, PriceSearchingService>();
            services.AddTransient<IProductInfoService, ProductInfoService>();
            services.AddTransient<IBeginTransactionService, BeginTransactionService>();
            services.AddTransient<ISetReservationService, SetReservationService>();
            services.AddTransient<ICommitTransactionService, CommitTransactionService>();
            services.AddTransient<IReservationDetailService, ReservationDetailService>();
            services.AddTransient<IBookingService, BookingService>();


            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //services.AddScoped<IUserRepository, UserRepository>();
            
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
