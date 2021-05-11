using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

using PizzaBox.Client.Web.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Storage;

/// navigate the user through Views
namespace PizzaBox.Client.Controllers
{
  [Route("[controller]")]
  public class OrderController : Controller
  {
    private readonly UnitOfWork _unitOfWork;

    public OrderController(UnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(OrderViewModel order)
    {
      if (ModelState.IsValid)
      {
        // Display the previously selected choices.
        var crust = _unitOfWork.Crusts.Select(c => c.Name == order.SelectedCrust).First();
        var size = _unitOfWork.Sizes.Select(s => s.Name == order.SelectedSize).First();
        // var toppings = new List<Topping>();

        // foreach (var item in order.SelectedToppings)
        // {
        //   toppings.Add(_unitOfWork.Toppings.Select(t => t.Name == item).First());
        // }

        // var newPizza = new CustomPizza { Crust = crust, Size = size };
        // var newOrder = new PizzaOrder(); newOrder.AddPizza(newPizza);

        // _unitOfWork.Orders.Insert(newOrder);
        // _unitOfWork.Save();

        // ViewBag.Order = newOrder;

        return View("checkout");
      }

      order.PopulatePizzaComponentChoices(_unitOfWork);

      return View("order", order);
    }// /ax 'Create'

  }// /cla 'OrderController'
}// /ns '..Controllers'
 // EoF