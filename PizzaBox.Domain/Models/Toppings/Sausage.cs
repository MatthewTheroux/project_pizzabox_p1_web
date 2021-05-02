using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Toppings
{
  public class Sausage : APizzaTopping
  {
    public Sausage()
    {
      name = "Sausage";
      veget = false;
      vegan = false;
      price = 1.50;
    }
  }
}