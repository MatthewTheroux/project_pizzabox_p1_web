using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
  ///
  public abstract class APizzaStore : AStore
  {
    public new List<PizzaOrder> Orders { get; set; }
    public APizzaStore() : this("a pizza store") { }
    public APizzaStore(string name) { Name = name; }
    public APizzaStore(APizzaStore store) : this(store.Name) { }

    // [III]. FOOT
    public override string ToString() { return Name; }
  }// /cla 'APizzaStore'
}// /ns ...Abstracts
 // EoF