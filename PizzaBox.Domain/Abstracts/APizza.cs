// [I]. HEAD
//  A] Libraries
using System.Collections.Generic;

using PizzaBox.Domain.Abstracts.PizzaComponents;
using PizzaBox.Domain.Abstracts.PizzaComponents.PizzaToppings;

using PizzaBox.Domain.Models.Orders;//<?>

///
namespace PizzaBox.Domain.Abstracts
{

  public abstract class APizza : AWare
  {
    public Order Order { get; set; } //<?>

    /// the name of the pizza
    public string Name { get; protected set; }

    public APizzaSize Size { get; set; }
    public APizzaCrust Crust { get; set; }
    public APizzaSauce Sauce { get; set; }
    public List<APizzaTopping> Toppings = new List<APizzaTopping>();

    public string PizzaType { get; protected set; }
    //public double Price { get; protected set; }
    private const int MAX_TOPPINGS = 5;

    protected List<AComponent> ingrediants;

    /// the direct constructor
    public APizza(APizzaSize _size, APizzaCrust _crust, APizzaSauce _sauce, APizzaToppingCheese _cheese, params APizzaTopping[] _toppings)
    {

    }

    // public abstract void addCrust(ASize crust = null);

    // public abstract void addSauce(APizzaSauce sauce = null);

    // public abstract void addTopping(params APizzaTopping[] toppings);

    // public void addCrust(ASize crust)
    // {
    //   Crust = crust;
    //   Price += crust.price;
    //   Price = Math.Round(Price, 2);
    // }

    // public override void addSauce(ASauce sauce)
    // {
    //   Sauce = sauce;
    //   Price += sauce.price;
    //   Price = Math.Round(Price, 2);
    // }

    // public override void addTopping(params APizzaTopping[] toppings)
    // {
    //   foreach (var topping in toppings)
    //   {
    //     if (topping == null)
    //       break;
    //     Toppings.Add(topping);
    //     topping.pizza = this;
    //     Price += topping.price;
    //   }

    //   Price = Math.Round(Price, 2);
    // }


  }
}