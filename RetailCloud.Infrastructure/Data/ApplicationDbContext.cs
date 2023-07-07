using Microsoft.EntityFrameworkCore;
using RetailCloud.Core.Entities;

namespace RetailCloud.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Barcode> Barcode { get; set; }
        public DbSet<Enterprises> Enterprises { get; set; }
        public DbSet<GroupProduct> GroupProduct { get; set; }
        public DbSet<Organization> Organization { get; set; }
        public DbSet<Producer> Producer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<SalesJournal> SalesJournal { get; set; }
        public DbSet<SalesJournalPosition> SalesJournalPosition { get; set; }
        public DbSet<Units> Units { get; set; }
        public DbSet<User> User { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=retailcloud;Username=postgres;Password=root");
        }
    }
}