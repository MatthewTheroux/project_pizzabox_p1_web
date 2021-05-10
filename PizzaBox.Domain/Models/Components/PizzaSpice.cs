// [I]. HEAD
//  A]
using System;

using PizzaBox.Domain.Abstracts;


namespace PizzaBox.Domain.Models.Components
{
  /// the spices to shake on top of the pizza
  public class PizzaSpice : APizzaComponent
  {
    //  B]
    public enum Choice
    {
      NONE = 0,

      HOUSE_ITALIAN,

      CAJUN_MARIACHI,


      STRUSSEL,

      UNSUPPORTED = 86

    }
    public Choice Selection { get; set; }

    // [II]. BODY
    // Direct cxtr
    public PizzaSpice(Choice _selection) { Selection = _selection; }

    public PizzaSpice(int _n) { Selection = (Choice)_n; }
    public PizzaSpice() : this(1) { }
    public PizzaSpice(string _selectionText)
    {
      _selectionText = _selectionText.Replace(" ", "_");

      Choice _selection = Choice.UNSUPPORTED;
      Enum.TryParse(_selectionText, true, out _selection);
      Selection = _selection;
    }

    // [III]. FOOT
    public override string ToString()
    {
      return this.GetType() + ":" + Selection.ToString();
    }

  }
}