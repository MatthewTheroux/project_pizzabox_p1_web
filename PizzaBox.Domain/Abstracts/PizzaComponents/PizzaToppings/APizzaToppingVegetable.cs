using System.ComponentModel.DataAnnotations;


///
namespace PizzaBox.Domain.Abstracts.PizzaComponents.PizzaToppings
{
  public class APizzaToppingVegetable : APizzaTopping
  {
    //[XmlInclude PizzaToppingMeatPepperoni]
    public APizzaToppingVegetable()
    {
      EntityName = "vegetable topping";
    }
  }
}