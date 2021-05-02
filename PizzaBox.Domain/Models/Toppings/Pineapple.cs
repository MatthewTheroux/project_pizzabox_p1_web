using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Toppings
{
  public class Pineapple : APizzaTopping
  {
    public Pineapple()
    {
      name = "Pineapple";
      veget = true;
      vegan = true;
      price = 0.60;
    }
  }
}