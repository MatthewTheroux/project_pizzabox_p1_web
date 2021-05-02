

namespace PizzaBox.Domain.Abstracts
{
  public abstract class APizzaSize : ASize
  {
    public int PriceMultiplier { get; set; }

    public APizzaSize()
    {
      SizeUnit = "inches";
    }
  }
}