using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Monies.Database;

namespace Monies.Terminal.Helpers
{
    public class MoniesDbContextDesignFactory : IDesignTimeDbContextFactory<MoniesDbContext>
    {
        public MoniesDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MoniesDbContext>();
            var cs = Settings.GetConnString();
            optionsBuilder.UseNpgsql(cs, opts => opts.SetPostgresVersion(9, 6));

            return new MoniesDbContext(optionsBuilder.Options);
        }
    }
}