using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Sauces
{
  public class Marinara : ASauce
  {
    public Marinara()
    {
      name = "Marinara";
      veget = false;
      vegan = false;
      price = 2.50;
    }
  }
}