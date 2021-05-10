// [I]. HEAD
//  A] Libraries
using System; //for enum

namespace PizzaBox.Domain.Models.Components.Toppings
{
  public class PizzaToppingCheese : APizzaTopping
  {
    //  B]
    public enum Choice
    {

      NO = 0,
      MOZZERELLA,
      MOZZ_PROV_MIX,
      PROVOLONE,
      CHEDDAR,
      GORGONZOLA,

      UNSUPPORTED = 86
    }
    public Choice Selection { get; set; }


    // [II]. BODY
    /// direct constructor
    public PizzaToppingCheese(Choice _selection) { Selection = _selection; }

    /// index-based constructor
    public PizzaToppingCheese(int _n) { Selection = (Choice)_n; }

    /// blank constructor
    public PizzaToppingCheese() : this(1) { }


    /// string constructor
    public PizzaToppingCheese(string _selectionText)
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
    public override string ToString()
    {
      return Selection.ToString();
    }
  }
}// 