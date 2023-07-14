using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Globalization;

using TSN.Application.Data;

namespace TSN.Application
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        string DefaultDb =>
        !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("SOTICKETDBURL")) ?
        Environment.GetEnvironmentVariable("TSNDBURL")! :
        "Server=localhost;Database=tsn;User Id=postgres;Include Error Detail=true";
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder
                .UseSnakeCaseNamingConvention(CultureInfo.CurrentCulture)
                .UseNpgsql(DefaultDb, m => m.MigrationsAssembly(typeof(AppDbContextFactory).Namespace));

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}