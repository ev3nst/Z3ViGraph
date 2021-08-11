using System;
using System.Linq;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using ViGraph.Utility.Config;
using ViGraph.Database;
using ViGraph.Models;

namespace ViGraph
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
			Configuration.GetSection("MySQLSettings").Bind(AppConfig.MySQLSettings);
			Configuration.GetSection("RootCredentials").Bind(AppConfig.RootCredentials);

			services.AddControllersWithViews();
			services.AddResponseCompression(options => {
				options.Providers.Add<BrotliCompressionProvider>();
				options.Providers.Add<GzipCompressionProvider>();
				options.MimeTypes =
					ResponseCompressionDefaults.MimeTypes.Concat(
						new[] { "image/svg+xml", "application/javascript+json+xml", "text/html+css+json+plain+xml" });
			});
			ConfigureEntityFramework(services);

			// Not Working ENUM implementation
			// services.AddSingleton<IRelationalTypeMappingSourcePlugin, EnumTypeMappingSourcePlugin>();

			services.AddIdentity<AppUser, AppRole>()
				.AddDefaultTokenProviders()
				.AddEntityFrameworkStores<ApplicationDbContext>();

			services.Configure<IdentityOptions>(options => {
				// Password settings.
				options.Password.RequiredLength = 6;

				// User settings.
				options.User.RequireUniqueEmail = true;
			});

			services.ConfigureApplicationCookie(options => {
				// Cookie settings
				options.Cookie.HttpOnly = true;
				options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

				options.LoginPath = "/auth/login";
				options.AccessDeniedPath = "/auth/unauthorized";
				options.SlidingExpiration = true;
			});

			services.AddHttpContextAccessor();
			services.AddSession(Options => {
				Options.IdleTimeout = TimeSpan.FromMinutes(10);
				Options.Cookie.HttpOnly = true;
				Options.Cookie.IsEssential = true;
			});
		}

		public void ConfigureEntityFramework(IServiceCollection services)
		{
			services.AddDbContextPool<ApplicationDbContext>(
				options => options.UseMySql(
					Configuration.GetConnectionString("DefaultConnection"),
					ServerVersion.AutoDetect(Configuration.GetConnectionString("DefaultConnection")),
					mysqlOptions => {
						mysqlOptions.MaxBatchSize(AppConfig.MySQLSettings.MaxBatchSize);
						if (AppConfig.MySQLSettings.RetryOnFail > 0) {
							mysqlOptions.EnableRetryOnFailure(AppConfig.MySQLSettings.RetryOnFail, TimeSpan.FromSeconds(5), null);
						}
					}
			));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			} else {
				app.UseExceptionHandler("/error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseResponseCompression();

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();
			app.UseSession();

			app.UseEndpoints(endpoints => {
				endpoints.MapControllerRoute(
					name: "Index",
					pattern: "/",
					defaults: new { controller = "Index", action = "Index" }
				);
			});
		}
	}
}
