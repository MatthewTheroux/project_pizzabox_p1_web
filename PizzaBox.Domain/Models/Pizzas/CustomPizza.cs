using System;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Pizzas
{
  public class CustomPizza : APizza
  {
    public override void addCrust(ASize crust)
    {
      Crust = crust;
      Price += crust.price;
      Price = Math.Round(Price, 2);
    }

    public override void addSauce(ASauce sauce)
    {
      Sauce = sauce;
      Price += sauce.price;
      Price = Math.Round(Price, 2);
    }

    public override void addTopping(params APizzaTopping[] toppings)
    {
      foreach (APizzaTopping topping in toppings)
      {
        if (topping == null)
          break;
        Toppings.Add(topping);
        topping.pizza = this;
        Price += topping.price;
      }
      Price = Math.Round(Price, 2);
    }

    public CustomPizza()
    {
      Name = "Custom Pizza";

    }
  }
}