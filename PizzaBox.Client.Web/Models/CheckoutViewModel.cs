// [I]. HEAD
//  A] Libraries
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using PizzaBox.Storage;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Domain.Models.Components.Toppings;

/// UX Models
namespace PizzaBox.Client.Web.Models
{
  public class CheckoutViewModel
  {
    //  B]
    // Hold the components from the order.
    public List<PizzaSize> Sizes { get; set; } = new List<PizzaSize>();
    public List<PizzaCrust> Crusts { get; set; } = new List<PizzaCrust>();
    public List<PizzaSauce> Sauces { get; set; } = new List<PizzaSauce>();
    public List<PizzaToppingCheese> Cheeses { get; set; } = new List<PizzaToppingCheese>();
    public List<APizzaTopping> Toppings { get; set; } = new List<APizzaTopping>();
    public List<PizzaSpice> Spices { get; set; } = new List<PizzaSpice>();

    public List<APizza> Pizzas { get; set; } = new List<APizza>();

    public List<PizzaOrder> Orders { get; set; } = new List<PizzaOrder>();

    //  C]
    /// a required parameterless constructor
    public CheckoutViewModel() { }

    /// retrieve the pizza component choices from the UoW.
    public void Populate(UnitOfWork unitOfWork)
    {
      Sizes = unitOfWork.Sizes.ToList(); //Select(size => !string.IsNullOrWhiteSpace(size.Name)).ToList();
      Crusts = unitOfWork.Crusts.ToList(); //.Select(crust => !string.IsNullOrWhiteSpace(crust.Name)).ToList();
      Sauces = unitOfWork.Sauces.ToList();//.Select(sauce => !string.IsNullOrWhiteSpace(sauce.Name)).ToList();
      Cheeses = unitOfWork.Cheeses.ToList();//.Select(sauce => !string.IsNullOrWhiteSpace(sauce.Name)).ToList();
      Toppings = unitOfWork.Toppings.ToList();//.Select(topping => !string.IsNullOrWhiteSpace(topping.Name)).ToList();
      Spices = unitOfWork.Spices.ToList();//.Select(sauce => !string.IsNullOrWhiteSpace(sauce.Name)).ToList();
    }// /md 'Populate' //<!> clean
  }// /cla
}// /ns