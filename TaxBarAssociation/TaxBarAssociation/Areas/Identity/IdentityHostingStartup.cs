using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaxBarAssociation.Areas.Identity.Data;

[assembly: HostingStartup(typeof(TaxBarAssociation.Areas.Identity.IdentityHostingStartup))]
namespace TaxBarAssociation.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                //services.AddDbContext<AppDBContext>(options =>
                //    options.UseSqlServer(
                //        context.Configuration.GetConnectionString("AppDBContextConnection")));
                //services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                //    .AddRoles<IdentityRole>()
                //    .AddEntityFrameworkStores<AppDBContext>();
                //services.AddIdentity<IdentityUser, IdentityRole>()
                // .AddDefaultUI()
                // .AddEntityFrameworkStores<AppDBContext>();
            });
        }
    }
}