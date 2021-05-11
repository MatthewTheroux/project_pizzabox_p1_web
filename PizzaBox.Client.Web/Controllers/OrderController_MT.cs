// [I]. HEAD
//  A] Libraries
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Npgsql.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

using PizzaBox.Client.Web.Models;

using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Stores;
using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Domain.Models.Components.Toppings;

using PizzaBox.Storage;
using PizzaBox.Storage.Repositories;

/// 
namespace PizzaBox.Client.Web.Controllers
{
  [Route("[controller]")]
  public class OrderController : Controller
  {
    private UnitOfWork _unitOfWork;

    /// constructor with UnitOfWork
    public OrderController(UnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

    // use polymorphism to populate different types.
    public void Populate(UnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

    [HttpGet]
    [HttpPost]
    [ValidateAntiForgeryToken] // significantly reduces invalid access
    public IActionResult Create(OrderViewModel order)

    {
      if (!ModelState.IsValid)
      {
        order.PopulatePizzaComponentChoices(_unitOfWork);
        return View("New Order Request.");
      }
      // else IsValid
      PizzaSize size = _unitOfWork.Sizes.Select(size => size.Name == order.SelectedSize).First();
      PizzaCrust crust = _unitOfWork.Crusts.Select(crust => crust.Name == order.SelectedCrust).First();
      PizzaSauce sauce = _unitOfWork.Sauces.Select(sauce => sauce.Name == order.SelectedSauce).First();
      PizzaToppingCheese cheese = _unitOfWork.Cheeses.Select(cheese => cheese.Name == order.SelectedCheese).First();

      List<APizzaTopping> toppings = new List<APizzaTopping>();
      foreach (APizzaTopping toppingSelected in order.SelectedToppings)
      {
        toppings.Add(_unitOfWork.Toppings.Select(topping => topping == toppingSelected).First());
      }

      APizza newPizza = new CustomPizza { Size = size, Crust = crust, Toppings = toppings };
      PizzaOrder newOrder = new PizzaOrder();
      newOrder.AddPizza(newPizza);


      _unitOfWork.Orders.Insert(newOrder);
      _unitOfWork.Save();

      ViewBag.Order = newOrder;

      //  c) foot
      /// Order complete.  Submit to cart.
      return View("checkout");

      //return View("order", order);
    }// /'Create' Order

  }// /cla 'OrderController'
}// /ns '..Controllers'
 // EoF