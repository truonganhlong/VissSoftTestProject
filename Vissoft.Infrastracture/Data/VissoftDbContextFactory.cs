using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vissoft.Infrastracture.Data
{
    public class VissoftDbContextFactory : IDesignTimeDbContextFactory<VissoftDbContext>
    {
        public VissoftDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("vissoftDb");

            var optionsBuilder = new DbContextOptionsBuilder<VissoftDbContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.Parse("8.0.31-mysql"));

            return new VissoftDbContext(optionsBuilder.Options);
        }
    }
}
