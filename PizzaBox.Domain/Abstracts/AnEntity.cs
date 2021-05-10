// [I]. HEAD
//  A] Libraries
// (none)

///
namespace PizzaBox.Domain.Abstracts
{
  /// organizes classes for database interactions
  public abstract class AnEntity
  {
    //  B] Properties
    public long EntityId { get; set; }
    public string EntityName { get; protected set; }
    public string Name { get; set; } = "unnamed entity";


    // [II]. BODY
    /// Automatically set the entity name of an entity as the name of the concrete class.
    public AnEntity() { EntityName = GetType().Name; }

    // [III]. FOOT
    /// Provide the string representation of the entity.
    public override string ToString()
    {
      return EntityName;
    }
  }// /cla 'AnEntity'
}// /ns '..Abstracts'
 // EoF