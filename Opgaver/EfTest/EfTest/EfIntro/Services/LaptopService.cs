using EfIntroSolution.Data;
using EfIntroSolution.Models;

namespace EfIntroSolution.Services
{
  public class LaptopService
  {
    AppDbContext dbContext;

    public LaptopService(AppDbContext dbContext)
    {
      this.dbContext = dbContext;
    }

    public void Add(Laptop laptop)
    {
      dbContext.Add(laptop);
      dbContext.SaveChanges();
    }
  }
}