

namespace PizzaBox.Domain.Abstracts
{
  public class AStoreOwner : AnEntity
  {
    public new string Name { get; set; }

    public string Password { get; } = "Password12345";
    public AStore Store { get; set; }
  }// /cla 'AStoreOwner'
}// /ns '..Abstracts'
 // EoF