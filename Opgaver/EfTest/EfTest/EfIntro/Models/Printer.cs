namespace EfIntroSolution.Models
{
  public class Printer
  {
    public int PrinterId { get; set; }
    public string Color { get; set; }
    public string Type { get; set; }
    public float Price { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }

    public override string ToString()
    {
      return string.Format("Printer({0}, {1}, {2}, {3}, {4}, {5})", PrinterId, Color, Type, Price, Price, Product);
    }

  }
}