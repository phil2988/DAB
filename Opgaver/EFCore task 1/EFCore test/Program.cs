using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace EFCore_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();

            using (var db = new MyDbContext())
            {
                var door = new Door()
                {
                    Type = "Wood",
                    Windows = true
                };
                db.doors.Add(door);
                db.SaveChanges();
            }

            var getDoor = new Door();
            using(var db = new MyDbContext())
            {
                getDoor = db.doors
                    .Single(b => b.DoorId == 3);
            }

            Console.WriteLine(getDoor.DoorId + " " + getDoor.Type + " " + getDoor.Windows);
        }
    }
}
