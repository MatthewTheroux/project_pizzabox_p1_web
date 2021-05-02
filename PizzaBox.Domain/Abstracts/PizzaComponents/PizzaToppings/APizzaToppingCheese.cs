using System.ComponentModel.DataAnnotations;


///
namespace PizzaBox.Domain.Abstracts.PizzaComponents.PizzaToppings
{
  public class APizzaToppingCheese : APizzaTopping
  {
    //[XmlInclude PizzaToppingMeatPepperoni]
    public APizzaToppingCheese()
    {
      EntityName = "cheese topping";
    }
  }
}