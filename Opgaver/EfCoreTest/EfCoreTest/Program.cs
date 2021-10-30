using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EfCoreTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDbContext myDb = new MyDbContext();

            if (myDb.people.SingleOrDefault(a => a.Name == "Anders") == default)
            {
                myDb.people.Add(
                    new Person()
                    {
                        Name = "Anders",
                        Adress = "Somwhere i dont know",
                        Age = 33,
                        Car = new Car()
                        {
                            LicensePlate = "HS25769",
                            Brand = "Skoda",
                            Model = "Fabia"
                        }
                    }
                );
                myDb.SaveChanges();
            }

            Person person = new Person();

            person = myDb.people.Single(b => b.Name == "Anders");

            Console.WriteLine("Say hello to {0}, He/She is {1} years old and lives on {2}", person.Name, person.Age, person.Adress);
            Console.WriteLine("They drive a {0} {1} with the license plate {2}", person.Car.Brand, person.Car.Model, person.Car.LicensePlate);
        }
    }
}
