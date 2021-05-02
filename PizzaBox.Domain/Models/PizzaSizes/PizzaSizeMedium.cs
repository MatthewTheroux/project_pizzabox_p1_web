using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Crusts
{
  public class PizzaSizeMedium : APizzaSize
  {
    public MediumCrust()
    {
      Name = "Medium";
      Size = 10;
      Price = 7.99;
    }
  }
}