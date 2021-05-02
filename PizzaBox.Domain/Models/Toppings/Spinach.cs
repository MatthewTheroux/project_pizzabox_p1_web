using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Toppings
{
  public class Spinach : APizzaTopping
  {
    public Spinach()
    {
      name = "Spinach";
      veget = true;
      vegan = true;
      price = 0.50;
    }
  }
}