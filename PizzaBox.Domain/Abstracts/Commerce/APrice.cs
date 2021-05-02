
///
namespace PizzaBox.Domain.Abstracts
{
  public class APrice
  {
    private decimal amount = 0M;
    public decimal Amount
    {
      get { return amount; }
      set { amount = value; }
    }

    private string currency = "USD";

    public string Currency
    {
      get { return currency; }
      set { currency = value; }
    }


  }
}