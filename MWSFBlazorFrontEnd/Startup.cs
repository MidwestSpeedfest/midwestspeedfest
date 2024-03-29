using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MWSFBlazorFrontEnd.Areas.Identity;
using MWSFBlazorFrontEnd.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using MWSFBlazorFrontEnd.Areas.Services;
using MWSFBlazorFrontEnd.Helpers.AutoMapper;
using MWSFDataAccess.DataAccess;
using MWSFDataAccess.DataService.FrontPage;
using Radzen;
using MudBlazor.Services;
using MWSFDataAccess.DataService.Alerts;
using MWSFDataAccess.DummyData;

namespace MWSFBlazorFrontEnd
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("MwsfDb")), ServiceLifetime.Transient);
            services.AddDefaultIdentity<IdentityUser>(options =>
                    options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddDatabaseDeveloperPageExceptionFilter();
            /*Packages*/
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            /*Radzen*/
            services.AddScoped<DialogService>();
            services.AddScoped<NotificationService>();
            services.AddScoped<TooltipService>();
            services.AddScoped<ContextMenuService>();
            /*MudBlazor*/
            services.AddMudServices();
            /*Oauth*/
            services.AddAuthentication()
                .AddDiscord(options =>
                {
                    options.ClientId = Configuration["Authentication:Discord:ClientId"];
                    options.ClientSecret = Configuration["Authentication:Discord:ClientSecret"];
                    options.Scope.Add("identify");
                    options.Scope.Add("guilds");
                    options.SaveTokens = true;
                });
            /*Identity Stuff*/
            services.AddTransient<IEmailSender, IdentityEmailSender>();
            /*MWSF stuff*/
            services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
            services.AddSingleton<IFrontPageDataService, FrontPageSqlDataService>();
            services.AddSingleton<IAlertDataService, AlertSqlDataService>();
            services.AddSingleton<IDummyDataService, DummyDataService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
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
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
