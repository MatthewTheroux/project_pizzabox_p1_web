using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Crusts
{
  public class XLargeCrust : ASize
  {
    public XLargeCrust()
    {
      name = "XLarge";
      Size = 18;
      price = 11.99;
      vegan = false;
      veget = false;
    }
  }
}