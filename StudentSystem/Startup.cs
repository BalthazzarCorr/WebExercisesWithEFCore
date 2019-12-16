namespace StudentSystem
{
	
	using Data;

	class Startup
	{
		static void Main()
		{
			using (var db = new MyDbContext())
			{
				PrepareDatabase(db);
			}
		}

		private static void PrepareDatabase(MyDbContext db)
		{

			db.Database.EnsureDeleted();
			db.Database.EnsureCreated();
		}
	}
}
