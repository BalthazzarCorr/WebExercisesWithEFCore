namespace ShopHierarchy
{
    using Microsoft.EntityFrameworkCore;
    public class MyDbContext : DbContext
    {
        public DbSet<Salesman> Salesmans { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=BALTSERVER\\SQLEXPRESS;Database=ShopDatabase;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Salesman>()
                .HasMany(c => c.Customers)
                .WithOne(e => e.Salesman)
                .HasForeignKey(s => s.SalesmanId);

        }
    }
}
