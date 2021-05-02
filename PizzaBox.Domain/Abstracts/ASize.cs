
namespace PizzaBox.Domain.Abstracts
{
  public abstract class ASize : AnEntity
  {
    protected uint Size { get; set; }
    public string SizeUnit { get; set; }
    //public abstract override string ToString();
  }
}