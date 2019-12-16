namespace StudentSystem.Data
{
	using Microsoft.EntityFrameworkCore;

	public class MyDbContext:DbContext
	{
		public DbSet<Student> Students { get; set; }

		public DbSet<Homework> Homeworks { get; set; }

		public DbSet<Resources> Resources { get; set; }

		public DbSet<Courses> Courses { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder builder)
		{
			builder
				.UseSqlServer(@"Server=DESKTOP-F1TG1GJ\SQLEXPRESS;Database=StudentSystem;Integrated Security=True;");
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder
				.Entity<StudentCourses>()
				.HasKey(k => new
			{
				k.StudentId, k.CourseId
			});

			builder
				.Entity<Student>()
				.HasMany(s => s.Courses)
				.WithOne(c => c.Student)
				.HasForeignKey(c => c.StudentId);
			builder
				.Entity<Student>()
				.HasMany(h => h.Homeworks)
				.WithOne(c => c.Student)
				.HasForeignKey(c => c.StudentId);

			builder
				.Entity<Courses>()
				.HasMany(s => s.Students)
				.WithOne(c => c.Courses)
				.HasForeignKey(c => c.CourseId);

			builder
				.Entity<Courses>()
				.HasMany(r => r.Resources)
				.WithOne(c => c.Courses)
				.HasForeignKey(c => c.CourseId);

			builder
				.Entity<Courses>()
				.HasMany(h => h.Homeworks)
				.WithOne(c => c.Courses)
				.HasForeignKey(c => c.CourseId);
		}
	}
}
