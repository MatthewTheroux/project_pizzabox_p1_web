namespace PizzaBox.Domain.Abstracts
{
  public abstract class ASize : AnEntity
  {
    public abstract string UnitOfMeasure { get; }
  }
}