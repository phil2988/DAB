namespace EfIntroSolution.Models
{
  public class Pc
  {
    public int PcId { get; set; }
    public float Speed { get; set; }
    public int Hd { get; set; }
    public float Price { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }

    public override string ToString()
    {
      return string.Format("Pc({0}, {1}, {2}, {3}, {4}, {5})", PcId, Speed, Hd, Price, Price, Product);
    }
  }
}