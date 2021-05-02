using System;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Sauces;
using PizzaBox.Domain.Models.Toppings;

namespace PizzaBox.Domain.Models.Pizzas
{
  public class MeatPizza : APizza
  {
    public override void addCrust(ASize crust)
    {
      Size = size;
      Crust = crust;
      Price += crust.price;
      Price = Math.Round(Price, 2);
    }

    public override void addSauce(APizzaSauce sauce)
    {
      Sauce = sauce;
      Price += sauce.price;
      Price = Math.Round(Price, 2);
    }

    public override void addTopping(params APizzaTopping[] toppings)
    {

      foreach (var topping in toppings)
      {
        if (topping == null)
          break;

        Toppings.Add(topping);
        topping.pizza = this;
        Price += topping.price;
      }
      Price = Math.Round(Price, 2);
    }
    public MeatPizza()
    {
      Name = "Meat Lover's Pizza";
      addSauce(new Marinara());
      addTopping(new APizzaTopping[3] { new Sausage(), new GrilledChicken(), new Pepporoni() });


    }
  }
}