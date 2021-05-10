// [I]. HEAD
//  A] Libraries
using System;

///
namespace PizzaBox.Domain.Models.Components.Toppings
{
  ///
  public class PizzaToppingMeat : APizzaTopping
  {
    //  B]
    public enum Choice
    {
      PEPPERONI = 1,
      HAM,
      CHICKEN,
      SAUSAGE,
      BEEF,
      BACON,


      UNSUPPORTED = 86
    }
    public Choice Selection { get; set; }


    // [II]. BODY
    /// direct constructor
    public PizzaToppingMeat(Choice _selection) { Selection = _selection; }

    /// index-based constructor
    public PizzaToppingMeat(int _n) { Selection = (Choice)_n; }

    /// parameterless constructor. yields 'PEPPERONI'
    public PizzaToppingMeat() : this(1) { }


    /// construct via string of the intended selection
    public PizzaToppingMeat(string _selectionText)
    {
      //   a) head: Normalize the string input, somewhat.
      _selectionText = _selectionText.Replace(" ", "_");

      //  b) body:
      // Assume a bad selection was made. 
      Choice _selection = Choice.UNSUPPORTED;
      Enum.TryParse(_selectionText, true, out _selection);  // Update, if valid.

      //  c) foot: 
      Selection = _selection;
    }

    // [III]. FOOT
    public override string ToString() { return Selection.ToString(); }

  }// /cla '..Meat'
}// /ns '..Toppings'
 // EoF