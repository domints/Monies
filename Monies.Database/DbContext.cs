using Marques.EFCore.SnakeCase;
using Microsoft.EntityFrameworkCore;
using Monies.Database.Models;

namespace Monies.Database
{
    public class MoniesDbContext : DbContext
    {
        public MoniesDbContext(DbContextOptions options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ToSnakeCase();
        }

        public DbSet<Salary> Salaries { get; set; }
        public DbSet<UserSetting> UserSettings { get; set; }
    }
}