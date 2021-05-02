using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Toppings
{
  public class Mozzerella : APizzaTopping
  {
    public Mozzerella()
    {
      name = "Mozzerella";
      veget = true;
      vegan = false;
      price = 0.50;
    }
  }
}