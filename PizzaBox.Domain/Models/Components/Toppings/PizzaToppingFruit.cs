// [I]. HEAD
//  A]
using System;

/// 
namespace PizzaBox.Domain.Models.Components.Toppings
{
  /// choices of fruit pizza toppings
  public class PizzaToppingFruit : APizzaTopping
  {
    //  B]
    public enum Choice
    {
      PINEAPPLE = 1,

      MANDARIN_ORANGE,

      APPLE,

      CHERRY,

      // Nuts are fruits, too.
      WALNUT,
      ALMOND,


      UNSUPPORTED = 86
    }
    public Choice Selection { get; set; }


    // [II]. BODY
    /// direct constructor
    public PizzaToppingFruit(Choice _selection) { Selection = _selection; }

    /// index-based constructor
    public PizzaToppingFruit(int _n) { Selection = (Choice)_n; }

    /// parameterless constructor
    public PizzaToppingFruit() : this(1) { }


    /// string constructor
    public PizzaToppingFruit(string _selectionText)
    {
      //   a) head: Normalize the string input, somewhat.
      _selectionText = _selectionText.Replace(" ", "_");

      //  b) body: 
      // assume a bad selection
      Choice _selection = Choice.UNSUPPORTED;
      Enum.TryParse(_selectionText, true, out _selection);  // update, if good.

      //  c) foot: 
      Selection = _selection;
    }

    #region listers
    //  B]

    #endregion listers
    // [III]. FOOT
    public override string ToString() { return Selection.ToString(); }

  }// /cla '..Fruit'
}// /ns '..Toppings'
 // EoF