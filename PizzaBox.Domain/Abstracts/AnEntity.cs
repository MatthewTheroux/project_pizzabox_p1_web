
namespace PizzaBox.Domain.Abstracts
{
  public abstract class AnEntity
  {
    public long EntityId { get; set; }
    public string EntityName { get; set; }

    public AnEntity()
    {
      /// automatically set the name of the entity as the name of the class
      EntityName = GetType().Name;
    }

    public override string ToString()
    {
      return EntityName;
    }
  }
}