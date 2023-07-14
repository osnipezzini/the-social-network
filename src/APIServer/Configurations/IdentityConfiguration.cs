using Microsoft.EntityFrameworkCore;

using System.Globalization;

using TSN.Application.Data;
using TSN.Application.Models;

namespace TSN.APIServer.Configurations;

public static class IdentityConfiguration
{
    public static WebApplicationBuilder ConfigureIdentity(this WebApplicationBuilder builder)
    {
        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options
            .UseSnakeCaseNamingConvention(CultureInfo.CurrentCulture)
            .UseNpgsql(connectionString));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddDefaultIdentity<User>(options =>
        {
            options.SignIn.RequireConfirmedAccount = true;
#if DEBUG
            options.SignIn.RequireConfirmedAccount = false;
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
#endif
        }).AddEntityFrameworkStores<ApplicationDbContext>();

        return builder;
    }
}
