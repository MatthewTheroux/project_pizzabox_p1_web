// [I]. HEAD
//  A] Libraries
using System;
using System.Text;

using PizzaBox.Domain.Models;
///
namespace PizzaBox.Domain.Abstracts
{
  ///
  public abstract class AsAWare
  {
    //  B] Fields & Properties
    /// yields the class type name;
    public string Type;

    /// how much customer pays to buy
    public Price Price { get; set; }


    // [II]. BODY
    // (idk)

    /// 
    public override string ToString()
    {
      return $"{Type} @{Price}";
    }

  }// /cla
}// /ns