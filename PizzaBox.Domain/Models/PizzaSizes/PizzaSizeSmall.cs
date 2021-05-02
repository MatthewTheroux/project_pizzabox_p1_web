using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Crusts
{
  public class SmallCrust : ASize
  {
    public SmallCrust()
    {
      name = "Small";
      Size = 8;
      price = 5.99;
      vegan = false;
      veget = false;
    }
  }
}