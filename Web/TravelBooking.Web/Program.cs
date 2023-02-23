﻿namespace TravelBooking.Web;

using System.Reflection;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TravelBooking.Common;
using TravelBooking.Data;
using TravelBooking.Data.Common;
using TravelBooking.Data.Common.Repositories;
using TravelBooking.Data.Models;
using TravelBooking.Data.Repositories;
using TravelBooking.Data.Seeding;
using TravelBooking.Services.Data.Bookings;
using TravelBooking.Services.Data.Users;
using TravelBooking.Services.Mapping;
using TravelBooking.Services.Messaging;
using TravelBooking.Web.ViewModels;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigureServices(builder.Services, builder.Configuration);
        var app = builder.Build();
        Configure(app);
        app.Run();
    }

    private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
            .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();

        services.Configure<CookiePolicyOptions>(
            options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

        services.AddControllersWithViews(
            options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            }).AddRazorRuntimeCompilation();

        services.AddAntiforgery(options => options.HeaderName = GlobalConstants.AntiforgeryHeaderName);
        services.AddRazorPages();
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddSingleton(configuration);

        // Data repositories
        services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        services.AddScoped<IDbQueryRunner, DbQueryRunner>();

        // Application services
        services.AddTransient<IEmailSender, NullMessageSender>();
        services.AddTransient<IBookingsService, BookingsService>();
        services.AddTransient<IUsersService, UsersService>();
    }

    private static void Configure(WebApplication app)
    {
        // Seed data on application startup
        using (var serviceScope = app.Services.CreateScope())
        {
            var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.Migrate();
            new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
        }

        AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseCookiePolicy();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
        app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();
    }
}
