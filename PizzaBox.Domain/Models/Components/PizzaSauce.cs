// [I]. HEAD
//  A]
using System;

using PizzaBox.Domain.Abstracts;


namespace PizzaBox.Domain.Models.Components
{
  public class PizzaSauce : APizzaComponent
  {
    //  B]
    public enum Choice
    {
      NONE = 0,
      SMOOTH_MARINARA,
      CHUNKY_MARINARA,
      NACHO_CHEESE,
      GARLIC_BUTTER,
      PESTO_ALFREDO,
      BBQ,
      GRAVY,

      UNSUPPORTED = 86
    }
    public Choice Selection { get; set; }


    // [II]. BODY
    /// direct constructor
    public PizzaSauce(Choice _selection) { Selection = _selection; }

    /// index-based constructor
    public PizzaSauce(int _n) { Selection = (Choice)_n; }

    /// blank constructor with default value
    public PizzaSauce() : this(1) { }

    /// string constructor
    public PizzaSauce(string _selectionText)
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
  }// /cla 'PizzaSauce'
}// /ns
 // EoF