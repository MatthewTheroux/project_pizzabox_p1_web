using System.ComponentModel.DataAnnotations;


///
namespace PizzaBox.Domain.Abstracts.PizzaComponents.PizzaToppings
{
  public class APizzaToppingMeat : APizzaTopping
  {
    //[XmlInclude PizzaToppingMeatPepperoni]
    public APizzaToppingMeat()
    {
      EntityName = "meat topping";
    }
  }
}