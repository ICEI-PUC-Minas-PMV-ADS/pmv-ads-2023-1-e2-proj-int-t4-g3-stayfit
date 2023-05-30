
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using StayFit.Context;
using StayFit.helpers;
using StayFit.helpers.Interfaces;
using StayFit.Models;
using StayFit.Repositories;
using StayFit.Repositories.Interfaces;

namespace StayFit
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
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 1;

			});

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
            {
                options.AccessDeniedPath = "/UserDanied";
                options.LoginPath = "/Login";
            });
            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IExercicioRepository, ExercicioRepository>();
            services.AddTransient<ITreinoRepository, TreinoRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IFichaRepository,FichaRepository>();
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IAvalicaoFisicaRepository, AvalicaoFisicaRepository>();
            services.AddTransient<IInsturtorRepository, InstrutorRepository>();
            //services.AddScoped<StayFit.helpers.Interfaces.ISession, Session>();
            services.AddSingleton<IHostEnvironment, HostingEnvironment>();
            services.AddControllersWithViews();

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.AddSession(s =>
            {
                s.Cookie.HttpOnly = true;
                s.Cookie.IsEssential = true;
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
            // app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "admin",
                pattern: "Admin/Cliente/{action}/{categoria?}",
                defaults: new { Controller = "AdminCliente", Action = "ListClient" }
                );

                endpoints.MapControllerRoute(
                   name: "admin",
                   pattern: "Admin/Cliente/{action}/{categoria?}",
                   defaults: new { Controller = "AdminCliente", Action = "CreateClient" }
                   );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Principal}/{action=Index}/{id?}");
            });
        }
    }
}