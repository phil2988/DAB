namespace EfIntroSolution.Models
{
  public class Product
  {
    public int Id { get; set; }
    public string Maker { get; set; }
    public string Model { get; set; }
    public string Type { get; set; }

    public override string ToString()
    {
      return string.Format("Product({0}, {1}, {2}, {3})", Id, Maker, Model, Type);
    }

  }
}