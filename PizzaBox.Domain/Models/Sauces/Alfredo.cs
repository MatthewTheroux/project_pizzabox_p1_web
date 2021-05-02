using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Sauces
{
  public class Alfredo : ASauce
  {
    public Alfredo()
    {
      name = "Alfredo";
      veget = false;
      vegan = false;
      price = 2.50;
    }
  }
}