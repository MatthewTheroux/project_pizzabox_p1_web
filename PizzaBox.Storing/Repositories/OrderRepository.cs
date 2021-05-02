using PizzaBox.Domain.Models.Orders;

namespace PizzaBox.Storing.Repositories
{
  public class OrderRepository
  {
    private readonly PizzaBoxContext _context;

    public OrderRepository(PizzaBoxContext context)
    {
      _context = context;
    }

    public void Create(Order order)
    {
      _context.orders.Add(order);
      _context.SaveChanges();
    }
  }
}