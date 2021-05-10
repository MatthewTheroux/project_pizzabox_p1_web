// [I]. HEAD
//  A] Libraries
using System; // for enum
using System.ComponentModel;

using PizzaBox.Domain.Abstracts;


namespace PizzaBox.Domain.Models.Components.Toppings
{
  public class PizzaToppingVegetable : APizzaTopping
  {
    //  B]
    public enum Choice
    {

      MUSHROOM = 1,

      ZUCCINI,

      BROCCOLI,

      ROASTED_RED_BELL_PEPPER,

      GREEN_BELL_PEPPER,

      ONION,

      ONION_RED,

      CARROT,

      BANANA_PEPPER,

      /// Pretend tomato is not a fruit.
      DICED_TOMATO,

      UNSUPPORTED = 86
    }
    public Choice Selection { get; set; }


    // [II]. BODY
    /// direct constructor
    public PizzaToppingVegetable(Choice _selection) { Selection = _selection; }

    /// index-based constructor
    public PizzaToppingVegetable(int _n) { Selection = (Choice)_n; }

    /// blank constructor
    public PizzaToppingVegetable() : this(1) { }


    /// string constructor
    public PizzaToppingVegetable(string _selectionText)
    {
      //   a) head: Normalize the string input, somewhat.
      _selectionText = _selectionText.Replace(" ", "_");

      //  b) body: 
      Choice _selection = Choice.UNSUPPORTED;
      Enum.TryParse(_selectionText, true, out _selection);

      //  c) foot: 
      Selection = _selection;
    }

    // [III]. FOOT
    public override string ToString()
    {
      return this.GetType() + ":" + Selection.ToString();
    }
  }
}