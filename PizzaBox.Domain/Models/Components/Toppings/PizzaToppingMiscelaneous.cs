// [I]. HEAD
//  A] Libraries
using System; //for enum

namespace PizzaBox.Domain.Models.Components.Toppings
{
  public class PizzaToppingMiscelaneous : APizzaTopping
  {
    //  B]
    public enum Choice
    {


      UNSUPPORTED = 86
    }
    public Choice Selection { get; set; }


    // [II]. BODY
    /// direct constructor
    public PizzaToppingMiscelaneous(Choice _selection) { Selection = _selection; }

    /// index-based constructor
    public PizzaToppingMiscelaneous(int _n) { Selection = (Choice)_n; }

    /// parameterless constructor
    public PizzaToppingMiscelaneous() : this(1) { }


    /// string constructor
    public PizzaToppingMiscelaneous(string _selectionText)
    {
      //   a) head: Normalize the string input, somewhat.
      _selectionText = _selectionText.Replace(" ", "_");

      //  b) body: 
      // Assume a bad selection.
      Choice _selection = Choice.UNSUPPORTED;
      Enum.TryParse(_selectionText, true, out _selection); // Update, if valid.

      //  c) foot: 
      Selection = _selection;
    }

    // [III]. FOOT
    public override string ToString() { return Selection.ToString(); }

  }// /cla '..Miscelaneous'
}// /ns '..Toppings'