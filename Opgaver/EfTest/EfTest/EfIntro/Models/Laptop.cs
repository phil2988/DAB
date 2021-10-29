namespace EfIntroSolution.Models
{
  public class Laptop
  {
    public int LaptopId { get; set; }
    public float Speed { get; set; }
    public int Hd { get; set; }
    public float Screen { get; set; }
    public float Price { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }

    public override string ToString()
    {
      return string.Format("Laptop({0}, {1}, {2}, {3}, {4}, {6}, {5})", LaptopId, Speed, Hd, Price, Price, Product, Screen);
    }

  }
}