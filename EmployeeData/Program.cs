using System;

namespace EmployeeData
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MyDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

            }
        }
    }
}
