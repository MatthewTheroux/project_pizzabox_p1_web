using System;
using System.IO;
using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Client.Singletons;
using PizzaBox.Domain.Models.Orders;
using PizzaBox.Storing.Repositories;
using PizzaBox.Storing;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;


namespace PizzaBox.Client
{
  internal class Program
  {
    private static readonly PizzaBoxContext _context = new PizzaBoxContext();
    private static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance(_context);
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance(_context);
    private static readonly CrustSingleton _crustSingleton = CrustSingleton.Instance(_context);
    private static readonly SauceSingleton _sauceSingleton = SauceSingleton.Instance(_context);
    private static readonly ToppingSingleton _toppingSingleton = ToppingSingleton.Instance(_context);
    private static readonly CustomerSingleton _customerSingleton = CustomerSingleton.Instance(_context);
    private static readonly OrderRepository _orderRepository = new OrderRepository(_context);

    public static void Run()
    {

      Customer customer;
      Order order = new Order();
      printList(_customerSingleton.Customers);

      var customerDec = Console.ReadLine();

      customerDec = inputCheck(customerDec, 0, _customerSingleton.Customers.Count);

      if (customerDec == "0")
      {
        customer = new Customer();
        Console.WriteLine("please insert your name:");
        customer.name = Console.ReadLine();
      }
      else
      {
        customer = _customerSingleton.Customers[int.Parse(customerDec) - 1];
      }
      printList(_storeSingleton.Stores);

      var storeDec = Console.ReadLine();

      storeDec = inputCheck(storeDec, 1, _storeSingleton.Stores.Count);

      var store = _storeSingleton.Stores[int.Parse(storeDec) - 1];


      if (!store.newOrder(customer, order))
      {
        Console.WriteLine("Connot make multiple orders within 2 hours");
        System.Environment.Exit(0);
      }


      orderPizzas(store, order);


      foreach (var pizza in order.pizzas)
      {
        var toppingsPrinted = new List<string>();

        if (pizza == null)
          break;
        Console.WriteLine($"Pizza Name: {pizza.Name} \nPizza Sauce: {pizza.Sauce.name}\t\tprice: ${pizza.Sauce.price} \nPizza Crust: {pizza.Crust.name}\t\tprice: ${pizza.Crust.price}");
        Console.WriteLine($"Toppings:");
        foreach (var topping in pizza.Toppings)
        {
          if (toppingsPrinted.Contains(topping.name))
            break;
          Console.WriteLine($"\t-{topping.name}\t\tprice: ${topping.price}");
          toppingsPrinted.Add(topping.name);
        }
        Console.WriteLine($"Total Price of Pizza: ${pizza.Price}");
      }

      Console.WriteLine($"Subtotal: ${order.price}\n");

      Console.WriteLine("1 to confirm order or 0 to cancel.");

      var finalDec = Console.ReadLine();

      finalDec = inputCheck(finalDec, 0, 1);

      if (int.Parse(finalDec) == 1)
      {

        _orderRepository.Create(order);

      }
      else
      {
        Console.WriteLine("Your order was canceled. thank you for considering us, have a nice day.");
      }




    }


    public static void printList(List<AStore> input)
    {

      Console.WriteLine($"Choose a store");

      int index = 0;
      foreach (var option in input)
      {
        Console.WriteLine($"{++index} - {option.Name}");
      }
    }

    public static void printList(List<APizza> input)
    {

      Console.WriteLine($"Choose a pizza");

      int index = 0;
      foreach (var option in input)
      {
        Console.WriteLine($"{++index} - {option.Name}");
      }
    }

    public static void printList(List<ASauce> input)
    {

      Console.WriteLine($"Choose a sauce");

      int index = 0;
      foreach (var option in input)
      {
        Console.WriteLine($"{++index} - {option.name}");
      }
    }

    public static void printList(List<Customer> input)
    {

      Console.WriteLine($"Are you a returning customer, if not press 0.");

      int index = 0;
      foreach (var option in input)
      {
        Console.WriteLine($"{++index} - {option.name}");
      }
    }

    public static void printList(List<APizzaTopping> input)
    {

      Console.WriteLine($"Choose a topping");

      int index = 0;
      foreach (var option in input)
      {
        Console.WriteLine($"{++index} - {option.name}");
      }
    }

    public static void printList(List<ASize> input)
    {

      Console.WriteLine($"Choose a crust");

      int index = 0;
      foreach (var option in input)
      {
        Console.WriteLine($"{++index} - {option.name}");
      }
    }

    public static string inputCheck(string input, int start, int end)
    {
      int a;
      while (!int.TryParse(input, out a) || a < start || a > end)
      {
        Console.WriteLine($"invalid input, input must be an integer between {start}, {end}");
        input = Console.ReadLine();
      }
      return input;
    }

    public static void getInput(string message, out int output, int start, int end)
    {
      Console.WriteLine(message);
      string mut = Console.ReadLine();
      mut = inputCheck(mut, start, end);
      output = int.Parse(mut);
    }

    public static void orderPizzas(AStore store, Order order)
    {
      int numPizzas;
      getInput("Choose between 1 pizza or 2.", out numPizzas, 1, 2);


      for (int i = 0; i < numPizzas; i++)
      {
        printList(_pizzaSingleton.pizzas);
        var pizzaDec = Console.ReadLine();
        pizzaDec = inputCheck(pizzaDec, 1, _pizzaSingleton.pizzas.Count);
        var pizza = _pizzaSingleton.pizzas[int.Parse(pizzaDec) - 1];
        printList(_crustSingleton.Crusts);
        var crustDec = Console.ReadLine();
        crustDec = inputCheck(crustDec, 1, _crustSingleton.Crusts.Count);
        var crust = _crustSingleton.Crusts[int.Parse(crustDec) - 1];
        pizza.addCrust(crust);
        printList(_sauceSingleton.Sauces);
        var sauceDec = Console.ReadLine();
        sauceDec = inputCheck(sauceDec, 1, _sauceSingleton.Sauces.Count);
        var sauce = _sauceSingleton.Sauces[int.Parse(sauceDec) - 1];
        pizza.addSauce(sauce);

        if (pizza.Name == "Custom Pizza")
        {
          var toppings = pickToppings();
          pizza.addTopping(toppings);
        }

        if (!store.addPizza(order, pizza))
        {
          break;
        }

      }

    }

    public static APizzaTopping[] pickToppings()
    {
      string toppingDec;
      APizzaTopping[] toppings = new APizzaTopping[5];
      Console.WriteLine("press 0 to exit the toppings menu.");
      for (int i = 0; i < 5; i++)
      {
        printList(_toppingSingleton.toppings);
        toppingDec = Console.ReadLine();
        toppingDec = inputCheck(toppingDec, 0, _toppingSingleton.toppings.Count);
        if (toppingDec == "0")
          break;

        toppings[i] = _toppingSingleton.toppings[int.Parse(toppingDec) - 1];
        Console.WriteLine("if that is enough toppings, press 0 to exit.");
      }

      return toppings;

    }

    private static void Main()
    {
      Run();
    }
  }
}
