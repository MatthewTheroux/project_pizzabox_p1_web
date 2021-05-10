// [I]. HEAD
//  A] Libraries
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Domain.Models.Components.Toppings;

///
namespace PizzaBox.Domain.Models.Pizzas
{
  /// a pizza topped with all of the meats
  public class MeatPizza : APizza
  {
    //  B] Fields and Properties


    // [II]. BODY
    ///
    public MeatPizza()
    {
      //  a) head
      Name = "Meat Pizza";

      //  b)  body
      // A Meat pizza could use a hearty crust and sauce, by default.
      //Crust = new PizzaCrust(PizzaCrust.Choice.CHICAGO_DEEP_DISH); //<!>anti-req
      //Sauce = new PizzaSauce(PizzaSauce.Choice.CHUNKY_MARINARA); //<!>anti-req

      // Dump all of the meat toppings on the pizza.
      AddTopping(new PizzaToppingMeat(PizzaToppingMeat.Choice.PEPPERONI));
      AddTopping(new PizzaToppingMeat(PizzaToppingMeat.Choice.HAM));
      AddTopping(new PizzaToppingMeat(PizzaToppingMeat.Choice.BACON));
      AddTopping(new PizzaToppingMeat(PizzaToppingMeat.Choice.SAUSAGE));
      AddTopping(new PizzaToppingMeat(PizzaToppingMeat.Choice.BEEF));

      //  c) foot  =created
    }
  }// /cla 'MeatPizza'
}// /ns '..Models.Pizzas'
 // EoF