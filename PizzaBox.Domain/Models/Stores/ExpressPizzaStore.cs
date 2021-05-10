
using PizzaBox.Domain.Abstracts;


namespace PizzaBox.Domain.Models.Stores
{
  public class ExpressPizzaStore : APizzaStore
  {

    public ExpressPizzaStore(string name = "")
    {
      EntityName = "Express Pizza";
      Name = name;
    }

    // [III]. FOOT
    ///
    public override string ToString() { return Name; }
  }// /cla 
}// /ns ..Stores
 // EoF