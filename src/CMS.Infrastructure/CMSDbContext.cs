using CMS.Domain.Models;
using CMS.Domain.Models.CowAggregate;
using CMS.Infrastructure.TypesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace CMS.Infrastructure
{
    public class CMSDbContext : DbContext
    {
        public DbSet<Cow> Cows { get; set; }
        public DbSet<Cowshed> Cowsheds { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Insemination> Inseminations { get; set; }
        public DbSet<Milking> Milkings { get; set; }
        public DbSet<Pregnancy> Pregnancies { get; set; }

        public const string DEFAULT_SCHEMA = "dbo";

        public CMSDbContext(Microsoft.EntityFrameworkCore.DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CowEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CowshedEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InseminationEntityConfiguration());
        }
    }
}
