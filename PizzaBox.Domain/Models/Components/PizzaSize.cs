// [I]. HEAD
//  A] Libraries
using System; // for enum
using System.ComponentModel;

using PizzaBox.Domain.Abstracts;

/// Size is a required component of APizza
namespace PizzaBox.Domain.Models.Components
{
  /// 
  public class PizzaSize : ASize
  {
    public override string UnitOfMeasure { get; } = "inches";

    /// Pizza size choices, |where index = the price multiplier.
    public enum Choice
    {
      [Description("6\"")] // inches
      ONE_MAN = 1,

      [Description("12\"")] // inches
      MEDIUM = 3,

      [Description("14\"")] // inches
      LARGE = 4,

      [Description("≈20\"")] // not really
      SHEET = 6,

      [Description("unsupported")]
      UNSUPPORTED = 0
    }

    public Choice Selection { get; private set; }

    /// How much
    public int PriceMultiplier() { return (int)Selection; }


    // [II]. BODY

    /// detailed constructor
    public PizzaSize(Choice _selection) { Selection = _selection; }

    /// integer constructor, by choice index
    public PizzaSize(int _n) { Selection = (Choice)_n; }

    /// blank constructor. chooses 'LARGE' by default, automatically.
    public PizzaSize() : this(Choice.LARGE) { }

    /// constructs based on the string name of the intended choice.
    public PizzaSize(string _selectionName)
    {
      _selectionName = _selectionName.Replace(" ", "_");

      Choice _selection = Choice.UNSUPPORTED;
      Enum.TryParse(_selectionName, true, out _selection);
      Selection = _selection;
    }

    // [III]. FOOT
    public override string ToString()
    {
      return Selection.ToString();
    }

  }// /cla 'Size'
}// /ns '..Models.Components'
 // EoF