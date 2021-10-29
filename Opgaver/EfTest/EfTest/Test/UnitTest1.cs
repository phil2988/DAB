using EfIntroSolution.Data;
using EfIntroSolution.Models;
using EfIntroSolution.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;

namespace Tests
{
  public class Tests
  {
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
      var connection = new SqliteConnection("DataSource=:memory:");
      connection.Open();

      try
      {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(connection)
            .Options;

        // Create the schema in the database
        using (var context = new AppDbContext(options))
        {
          context.Database.EnsureCreated();
        }

        // Run the test against one instance of the context
        using (var context = new AppDbContext(options))
        {
          var service = new LaptopService(context);
          var product = new Product()
          {
            Maker = "MakerTest",
            Model = "ModelTest",
            Type = "typeTest"
          };
          var laptop = new Laptop()
          {
            Product = product,
            Hd = 0,
            Price = 100,
            Screen = 0,
            Speed = 0
          };
          service.Add(laptop);
          context.SaveChanges();
        }

        // Use a separate instance of the context to verify correct data was saved to database
        using (var context = new AppDbContext(options))
        {
          Assert.AreEqual(1, context.laptops.Count());
          Assert.AreEqual(100, context.laptops.Single().Price);
        }
      }
      finally
      {
        connection.Close();
      }

    }
  }
}