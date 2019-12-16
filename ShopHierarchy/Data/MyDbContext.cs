namespace ShopHierarchy.Data
{

	using Microsoft.EntityFrameworkCore;
	public class MyDbContext : DbContext
	{
		public DbSet<Salesman> Salesmans { get; set; }

		public DbSet<Customer> Customers { get; set; }

		public DbSet<Order> Orders { get; set; }

		public DbSet<Review> Reviews { get; set; }

		public DbSet<Item> Items { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder
				.UseSqlServer(@"Server=DESKTOP-F1TG1GJ\SQLEXPRESS;Database=ShopDatabase;Integrated Security=True;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder
				.Entity<Customer>()
				.HasOne(c => c.Salesman)
				.WithMany(s => s.Customers)
				.HasForeignKey(c => c.SalesmanId);

			modelBuilder
				.Entity<Order>()
				.HasOne(o => o.Customer)
				.WithMany(c => c.Orders)
				.HasForeignKey(o => o.CustomerId);


			modelBuilder
				.Entity<Review>()
				.HasOne(r => r.Customer)
				.WithMany(c => c.Reviews)
				.HasForeignKey(r => r.CustomerId);


			modelBuilder
				.Entity<ItemOrder>()
				.HasKey(io => new
				{
					io.ItemId, io.OrderId
				});


			modelBuilder
				.Entity<Item>()
				.HasMany(i => i.Orders)
				.WithOne(o => o.Item)
				.HasForeignKey(io=>io.ItemId);

			modelBuilder
				.Entity<Order>()
				.HasMany(o => o.Items)
				.WithOne(io => io.Order)
				.HasForeignKey(io => io.OrderId);

			modelBuilder
				.Entity<Item>()
				.HasMany(i => i.Reviews)
				.WithOne(r => r.Item)
				.HasForeignKey(r => r.ItemId);
		}
	}
}
