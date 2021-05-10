// [I]. HEAD
//  A] Library
using System; // for enum
using System.Collections.Generic;

using PizzaBox.Domain.Abstracts;

/// the things that make up a pizza
namespace PizzaBox.Domain.Models.Components
{
  public class PizzaCrust : APizzaComponent
  {
    //  B]
    public enum Choice
    {
      // thin --> thick
      ADKINS_CRUSTLESS = 0,
      CRACKER_THIN,
      NY_THIN,
      BUBBLY_ITALIAN,
      TRADITIONAL_PAN,
      CHICAGO_DEEP_DISH,
      STUFFED,

      CALZONE,
      FOLDED_PITA,
      SANDWICH_ROLL,

      UNSUPPORTED = 86
    }
    public Choice Selection { get; set; }

    // [II]. BODY
    ///  direct cxtr
    public PizzaCrust(Choice _selection) { Selection = _selection; }

    public PizzaCrust(int _n) { Selection = (Choice)_n; }
    public PizzaCrust() : this(1) { }
    /// smart cxtr from string
    public PizzaCrust(string _selectionText)
    {
      _selectionText = _selectionText.Replace(" ", "_");

      Choice _selection = Choice.UNSUPPORTED;
      Enum.TryParse(_selectionText, true, out _selection);
      Selection = _selection;
    }

    #region listers
    ///  B]
    ///   1.
    public List<Choice> ListChoices() //<?>
    {
      //  a) head
      List<Choice> choices = new List<Choice>();

      //  b) body
      foreach (int index in Enum.GetValues(typeof(Choice)))
      {
        choices.Add((Choice)index);
      }

      //  c) foot
      return choices;
    }// /md 'GetChoices

    ///   2.
    public List<PizzaCrust> ListCrusts()
    {
      //  a) head
      List<PizzaCrust> crusts = new List<PizzaCrust>();

      //  b) body
      foreach (int index in Enum.GetValues(typeof(Choice)))
      {
        crusts.Add(new PizzaCrust(index));
      }

      //  c) foot
      return crusts;
    }// /md 'GetCrusts'

    ///   3.
    public List<string> ListChoiceNames()
    {
      //  a) head
      List<string> names = new List<string>();

      //  b) body
      foreach (string name in Enum.GetNames(typeof(Choice)))
      {
        if (name != "UNSUPPORTED" && name != "NO" && name != "NONE")
        {
          names.Add(name);
        }
      }

      //  c) foot
      return names;
    }// /md 'ListChoiceNames'
    #endregion listers


    // [III]. FOOT
    public override string ToString() { return Selection.ToString(); }

  }// /cla '..Crust'
}// /ns '..Components'
 // EoF