// [I]. HEAD
//  A] Libraries
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Domain.Models.Components.Toppings;

/// 
namespace PizzaBox.Domain.Abstracts
{
  //[DataContract]
  [XmlInclude(typeof(CheesePizza))]
  [XmlInclude(typeof(PepperoniPizza))]
  [XmlInclude(typeof(VegetablePizza))]
  [XmlInclude(typeof(MeatPizza))]
  [XmlInclude(typeof(CustomPizza))]

  public abstract class APizza : AWare
  {    //  B] Fields and Properties 
    public new string Name { get; set; }
    public PizzaSize Size { get; set; }
    public long SizeEntityId { get; set; }//<?>
    public PizzaCrust Crust { get; set; }
    public PizzaSauce Sauce { get; set; }
    public PizzaToppingCheese Cheese { get; set; }
    public List<APizzaTopping> Toppings { get; set; }
    public PizzaSpice Spice { get; set; }

    /// i.e., a one-man pizza with no toppings is $5.
    private static readonly Price BASE_PRICE = new Price(5.00M);

    /// the order that owns this pizza
    public PizzaOrder Order { get; set; } = null;


    /// Calculates the full price of the pizza, based on size and # of toppings
    public new Price Price
    {
      get
      {
        return new Price(
          Size.PriceMultiplier() *
          (BASE_PRICE.Amount // of a pizza
           + (Toppings.Count * APizzaTopping.BASE_PRICE.Amount)
          ));
      }
    }

    // [II]. BODY
    /// Construct a default-defined pizza (as a concrete child).
    public APizza() { Factory(); }
    /// 
    private void Factory()
    {
      // Fill with defaults.
      Size = new PizzaSize(1);
      SizeEntityId = 1; //"one-man"
      Crust = new PizzaCrust();
      Sauce = new PizzaSauce();
      Cheese = new Models.Components.Toppings.PizzaToppingCheese();
      Toppings = new List<APizzaTopping>(); // = no toppings
      Spice = new PizzaSpice();
    }// /defaut inherited factory

    //  B] Add | Remove to this Pizza.
    public void AddTopping(APizzaTopping topping) { Toppings.Add(topping); }
    public void AddTopping(List<APizzaTopping> toppings)
    {
      foreach (APizzaTopping topping in toppings)
      {
        AddTopping(topping);
      }
    }

    public void RemoveTopping(int index) { Toppings.RemoveAt(index); }
    public void RemoveTopping(List<int> indicies)
    {
      foreach (int index in indicies)
      {
        RemoveTopping(index);
      }
    }

    // [III]. FOOT
    /// the string representation of the pizza
    public override string ToString()
    {
      //  a) head
      StringBuilder pizzaStringBuilder = new StringBuilder("{a ");

      //  b) body
      pizzaStringBuilder.Append($"a {Size.ToString()} ");
      pizzaStringBuilder.Append($"{Crust.ToString()} crust pizza, with ");
      pizzaStringBuilder.Append($"with {Sauce.ToString()} sauce, ");
      pizzaStringBuilder.Append($"{Cheese.ToString()} cheese, ");

      foreach (APizzaTopping _topping in Toppings)
      {
        pizzaStringBuilder.Append($"{_topping.ToString()}, ");
      }
      pizzaStringBuilder.Append($"and {Spice} spices");
      pizzaStringBuilder.Append($" ${Price.ToString()}");

      //  c) foot
      return pizzaStringBuilder.ToString();
    }// /'ToString'

  }// /cla 'APizza'
}// /ns '..Abstracts'
 // EoF