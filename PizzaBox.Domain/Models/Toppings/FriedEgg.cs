using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Toppings
{
  public class FriedEgg : APizzaTopping
  {
    public FriedEgg()
    {
      name = "FriedEgg";
      veget = true;
      vegan = false;
      price = 0.99;
    }
  }
}