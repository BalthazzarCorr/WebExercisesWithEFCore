namespace ShopHierarchy
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
				.Entity<Salesman>()
				.HasMany(c => c.Customers)
				.WithOne(e => e.Salesman)
				.HasForeignKey(s => s.SalesmanId);

			modelBuilder
				.Entity<Order>()
				.HasOne(c => c.Customer)
				.WithMany(c => c.Orders)
				.HasForeignKey(c => c.CustomerId);


			modelBuilder
				.Entity<Review>()
				.HasOne(c => c.Customer)
				.WithMany(r => r.Reviews)
				.HasForeignKey(c => c.CustomerId);


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
				.HasMany(i => i.Items)
				.WithOne(o => o.Order)
				.HasForeignKey(o => o.OrderId);

			modelBuilder
				.Entity<Item>()
				.HasMany(r => r.Reviews)
				.WithOne(i => i.Item)
				.HasForeignKey(k => k.ItemId);
		}
	}
}
