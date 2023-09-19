using InternProject.Database.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace InternProject.Database
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {}

        public DbSet<regions> Regions { get; set; }
        public DbSet<countries> Countries { get; set; }
        public DbSet<locations> Locations { get; set; }
        public DbSet<jobs> Jobs { get; set; }
        public DbSet<departments> Departments { get; set; }
        public DbSet<employees> Employees { get; set; }
        public DbSet<dependents> Dependents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            configurationBuilder.Properties<DateOnly>()
                                .HaveConversion<Converter>()
                                .HaveColumnType("date");
        }
    }
}
