using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Toppings
{
  public class Parmesan : APizzaTopping
  {
    public Parmesan()
    {
      name = "Parmesan";
      veget = true;
      vegan = false;
      price = 0.50;
    }
  }
}