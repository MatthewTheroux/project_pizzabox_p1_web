// [I]. HEAD
//  A] Libraries
using System;
using System.Collections.Generic;
using System.Text;

using PizzaBox.Domain.Abstracts;

///
namespace PizzaBox.Domain.Models
{
  public class PizzaOrder : APizzaOrder
  {
    //  B] fields & props
    public DateTime BeganAtTimestamp { get; set; }

    public Customer Customer { get; private set; }
    public APizzaStore Store { get; private set; }
    public List<APizza> Pizzas { get; private set; }
    public const int MAXIMUM_NUMBER_OF_PIZZAS = 5;

    public DateTime SentAt { get; set; }

    public Price TotalPrice
    {
      get
      {
        decimal totalPrice = 0M;
        foreach (APizza pizza in Pizzas)
        {
          totalPrice += (decimal)pizza.Price.Amount;
        }
        return new Price();
      }
    }// /'TotalPrice'


    // [II]. BODY
    //   Constructors
    /// direct constructor
    public PizzaOrder(Customer customer, APizzaStore store, List<APizza> pizzas)
    {
      BeganAtTimestamp = DateTime.Now;
      Customer = customer;
      Store = store;
      Pizzas = pizzas;
    }
    /// 1-pizza constructor
    public PizzaOrder(Customer customer, APizzaStore store, APizza pizza)
    {
      Customer = customer;
      Store = store;
      List<APizza> pizzas = new List<APizza>();
      pizzas.Add(pizza);
      Pizzas = pizzas;
    }

    /// parameterless constructor = new blank order
    public PizzaOrder()
    {
      BeganAtTimestamp = DateTime.Now;
      Pizzas = new List<APizza>();
    }

    //  B] Add | Remove to this order
    public void AddPizza(APizza pizza) { Pizzas.Add(pizza); }
    public void AddPizza(List<APizza> pizzas)
    {
      foreach (APizza pizza in pizzas) { AddPizza(pizza); }
    }

    public void RemovePizza(int index) { Pizzas.RemoveAt(index); }
    public void RemovePizza(List<int> indices)
    {
      foreach (int index in indices)
      {
        RemovePizza(index);
      }
    }


    // [III]. FOOT
    public override string ToString()
    {
      string time = BeganAtTimestamp.ToLocalTime().ToString();
      return $"{EntityId} {Customer} {Store} ${TotalPrice}";
    }

    ///
    public string CheckoutReport()
    {
      //  a) head
      StringBuilder report = new StringBuilder();
      string createdAt = BeganAtTimestamp.ToLocalTime().ToString();

      //  b) body
      report.AppendLine($"Order Created @{createdAt}");
      report.AppendLine($"for {Customer}");
      report.AppendLine($"at {Store}");

      int _index = 0;
      foreach (APizza _pizza in Pizzas)
      {
        report.AppendLine("............................");

        report.Append($"Pizza {++_index}: ");
        report.AppendLine(_pizza.ToString());
      }
      report.AppendLine("------------------------------");
      report.AppendLine($"Order Total: ${TotalPrice.ToString()}");
      report.AppendLine($"Sales Tax at {TotalPrice.SalesTaxRate * 100}%: ${TotalPrice.SalesTax})");
      report.AppendLine($"Final total with tax: ${TotalPrice.WithTax}");
      report.AppendLine("==============================");
      report.AppendLine();


      //  c) foot
      return report.ToString();
    }// /'CheckoutReport'

    //public void Review() { }
    //public void SendIt() { }

  }// /cla 'PizzaOrder'
}// /ns '..
 // EoF