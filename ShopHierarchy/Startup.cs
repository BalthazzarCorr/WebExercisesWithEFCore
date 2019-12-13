namespace ShopHierarchy
{
    using System;
    class Startup
    {
        static void Main()
        {
            using (var db = new MyDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
        }
    }
}
