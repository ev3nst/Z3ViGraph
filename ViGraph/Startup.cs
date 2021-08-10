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

			services.AddIdentity<AppUser, IdentityRole>()
				.AddDefaultTokenProviders()
				.AddEntityFrameworkStores<ApplicationDbContext>();
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
						mysqlOptions.MaxBatchSize(int.Parse(Configuration.GetSection("MaxBatchSize").Value));
						int retryOnFail = int.Parse(Configuration.GetSection("RetryOnFail").Value);
						if (retryOnFail > 0) {
							mysqlOptions.EnableRetryOnFailure(retryOnFail, TimeSpan.FromSeconds(5), null);
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
				app.UseExceptionHandler("/Home/Error");
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
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
