
using System.IO;

using PizzaBox.Domain.Abstracts;


namespace PizzaBox.Domain.Models.Stores
{
  public class FamilyPizzaStore : AStore
  {

    public FamilyPizzaStore()
    {
      Name = "Family Pizza Store";
    }



    // [III]. FOOT
    ///
    public override string ToString()
    {
      return Name;
    }
  }
}