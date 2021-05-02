// [I]. HEAD
//  A] Libraries
//...

///
namespace PizzaBox.Domain.Abstracts
{
  /// an entity that can be bought and sold
  public abstract class AWare : AnEntity
  {
    public double Price { get; set; }


    public AWare() { EntityName = "(a ware"; }
  }
}
