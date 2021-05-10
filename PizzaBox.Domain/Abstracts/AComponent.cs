// [I]. HEAD
//  A] Libraries

/// 
namespace PizzaBox.Domain.Abstracts
{
  public abstract class AComponent : AnEntity
  {
    public string ComponentName { get; protected set; }


    // [II]. BODY
    public AComponent()
    {
      ComponentName = this.GetType().Name;
    }

    // [III]. FOOT
    public abstract override string ToString();


  }// /cla 'AComponent'
}// /ns '..Abstracts'
 // EoF