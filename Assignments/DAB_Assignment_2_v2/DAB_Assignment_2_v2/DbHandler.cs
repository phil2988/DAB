using DAB_Assignment_2_v2.Architecture;
using DAB_Assignment_2_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB_Assignment_2_v2
{
    class DbHandler
    {
        private readonly DatabaseContext dbContext;
        public DbHandler(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void SeedData()
        {
            dbContext.Activity.AddRange(
                new Activity { AcitivtyName = "Football" },
                new Activity { AcitivtyName = "Golf" },
                new Activity { AcitivtyName = "Chess" }
            );
            dbContext.SaveChanges();

            dbContext.Society.Add(
                new Society {
                    Cvr = 11111111,
                    Address = "Manchester alé 231",
                    AcivityId = dbContext.Activity
                        .FirstOrDefault(e => e.AcitivtyName == "Football")
                        .ActivityId
                }
            );
            dbContext.SaveChanges();

            dbContext.Society.Add(
                new Society
                {
                    Cvr = 22222222,
                    Address = "Washington Street 11",
                    AcivityId = dbContext.Activity
                        .FirstOrDefault(e => e.AcitivtyName == "Golf")
                        .ActivityId
                }
            );

            dbContext.Society.Add(
                new Society
                {
                    Cvr = 33333333,
                    Address = "No Creativity street 69",
                    AcivityId = dbContext.Activity
                        .FirstOrDefault(e => e.AcitivtyName == "Chess")
                        .ActivityId
                }
            );
            dbContext.SaveChanges();

            dbContext.Municipality.AddRange(
                new Municipality
                {
                    Societies = dbContext.Society.ToList()
                }
            );
            dbContext.SaveChanges();
        }
    }
}
