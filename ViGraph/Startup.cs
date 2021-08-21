using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

using ViGraph.Models;
using ViGraph.Database;
using ViGraph.Repository;
using ViGraph.Repository.IRepository;
using ViGraph.Middlewares.Permission;
using ViGraph.Middlewares.ClaimTransformations;
using ViGraph.Utility;

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
			Configuration.GetSection("AppMeta").Bind(AppConfig.AppMeta);
			Configuration.GetSection("MySQLSettings").Bind(AppConfig.MySQLSettings);
			Configuration.GetSection("RootCredentials").Bind(AppConfig.RootCredentials);

			services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });
			services.AddMvc()
			.AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
			.AddDataAnnotationsLocalization();

			services.Configure<RequestLocalizationOptions>(
				opt => {
					var supportedCultures = new[] { new CultureInfo("tr"), new CultureInfo("en") };
					opt.DefaultRequestCulture = new RequestCulture("tr");
					opt.SupportedCultures = supportedCultures;
					opt.SupportedUICultures = supportedCultures;
					opt.RequestCultureProviders = new List<IRequestCultureProvider> {
						new QueryStringRequestCultureProvider(),
						new CookieRequestCultureProvider()
					};
				}
			);

			services.AddScoped<IClaimsTransformation, AddRoleClaims>();
			services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
			services.AddScoped<IAuthorizationHandler, PermissionGuard>();

			// Repository Classes
			services.AddScoped<IAppRoleRepository, AppRoleRepository>();
			services.AddScoped<IAppUserRepository, AppUserRepository>();

			services.AddControllersWithViews().AddJsonOptions(
				opts => {
					opts.JsonSerializerOptions.PropertyNamingPolicy = null;
                    opts.JsonSerializerOptions.MaxDepth = 0;
				}
			);

			services.AddResponseCompression(options => {
				options.Providers.Add<BrotliCompressionProvider>();
				options.Providers.Add<GzipCompressionProvider>();
				options.MimeTypes =
					ResponseCompressionDefaults.MimeTypes.Concat(
						new[] { "image/svg+xml", "application/javascript+json+xml", "text/html+css+json+plain+xml" });
			});
			ConfigureEntityFramework(services);

			/*
            services.AddLogging(builder =>
                builder
                    .AddConfiguration(Configuration.GetSection("Logging"))
                    .AddConsole()
                    .AddDebug()
            );
            */

			services.AddIdentity<AppUser, AppRole>()
				.AddDefaultTokenProviders()
				.AddEntityFrameworkStores<ApplicationDbContext>();

			services.Configure<IdentityOptions>(options => {
				// Password settings.
				options.Password.RequiredLength = 6;

				// User settings.
				options.User.RequireUniqueEmail = true;

				// Sign In settings.
				options.SignIn.RequireConfirmedPhoneNumber = false;
				options.SignIn.RequireConfirmedEmail = false;
				options.SignIn.RequireConfirmedAccount = false;
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
				options => options.UseMySql( // .EnableSensitiveDataLogging()
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

			app.UseRequestLocalization(
				app.ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value
			);

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
