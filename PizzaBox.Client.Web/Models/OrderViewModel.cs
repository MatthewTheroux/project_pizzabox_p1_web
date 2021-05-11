// [I]. HEAD
//  A] Libraries
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using PizzaBox.Storage;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Domain.Models.Components.Toppings;

/// UX Models
namespace PizzaBox.Client.Web.Models
{
  /// the page from which one orders pizza.
  public class OrderViewModel
  {
    // Hold the components for the pizza and for the order.
    public List<PizzaSize> Sizes { get; set; } = new List<PizzaSize>();
    public List<PizzaCrust> Crusts { get; set; } = new List<PizzaCrust>();
    public List<PizzaSauce> Sauces { get; set; } = new List<PizzaSauce>();
    public List<PizzaToppingCheese> Cheeses { get; set; } = new List<PizzaToppingCheese>();
    public List<APizzaTopping> Toppings { get; set; } = new List<APizzaTopping>();
    public List<PizzaSpice> Spices { get; set; } = new List<PizzaSpice>();

    public List<APizza> Pizzas { get; set; } = new List<APizza>();

    public List<PizzaOrder> Orders { get; set; } = new List<PizzaOrder>();



    // Capture the user's selections.
    [Required(ErrorMessage = "Please select a size.")]
    [DataType(DataType.Text)]
    public string SelectedSize { get; set; }

    [Required(ErrorMessage = "Please select a crust type.")]
    [DataType(DataType.Text)]

    public string SelectedCrust { get; set; }

    [Required(ErrorMessage = "Please select a sauce.")]
    [DataType(DataType.Text)]
    public string SelectedSauce { get; set; }

    [Required(ErrorMessage = "Please select a cheese.")]
    [DataType(DataType.Text)]
    public string SelectedCheese { get; set; }

    [Required(ErrorMessage = "Please select some toppings.")]
    [DataType(DataType.Text)]

    public List<APizzaTopping> SelectedToppings { get; set; }

    [Required(ErrorMessage = "Please select a spice.")]
    [DataType(DataType.Text)]
    public string SelectedSpice { get; set; }


    /// a required parameterless constructor
    public OrderViewModel() { }

    /// retrieve the pizza component choices from the UoW.
    public void PopulatePizzaComponentChoices(UnitOfWork unitOfWork)
    {
      Sizes = unitOfWork.Sizes.ToList(); //Select(size => !string.IsNullOrWhiteSpace(size.Name)).ToList();
      Crusts = unitOfWork.Crusts.ToList(); //.Select(crust => !string.IsNullOrWhiteSpace(crust.Name)).ToList();
      Sauces = unitOfWork.Sauces.ToList(); //.Select(sauce => !string.IsNullOrWhiteSpace(sauce.Name)).ToList();
      Cheeses = unitOfWork.Cheeses.ToList(); //.Select(sauce => !string.IsNullOrWhiteSpace(sauce.Name)).ToList();
      Toppings = unitOfWork.Toppings.ToList(); //.Select(topping => !string.IsNullOrWhiteSpace(topping.Name)).ToList();
      Spices = unitOfWork.Spices.ToList(); //.Select(sauce => !string.IsNullOrWhiteSpace(sauce.Name)).ToList();
    }// /md 'Populate' //<!> clean


    // [III]. FOOT
    /// <summary> Validate the form's user inputs before sending </summary>
    /// <returns> validation error results </returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      // Validate that the number of toppings are within range.
      if (SelectedToppings.Count < 2 || SelectedToppings.Count > 5)
      {
        yield return new ValidationResult("Please select at least 2, but no more than 5, toppings", new[] { "SelectedToppings" });
      }
      if (SelectedCrust == SelectedSize)
      {
        yield return new ValidationResult("Crust type cannot be a Size.");
      }
    }// /form validations

  }// /cla 'OrderViewModel'
}// /ns '..Web.Models'
 // EoF