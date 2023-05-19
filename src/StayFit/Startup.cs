
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using StayFit.Context;
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
            services.AddTransient<IExercicioRepository, ExercicioRepository>();
            services.AddTransient<ITreinoRepository, TreinoRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IFichaRepository,FichaRepository>();
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

			services.AddSingleton<IHostEnvironment, HostingEnvironment>();
            services.AddControllersWithViews();
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

            app.UseAuthorization();

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
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}