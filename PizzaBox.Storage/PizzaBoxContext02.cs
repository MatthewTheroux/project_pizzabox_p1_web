// [I]. HEAD
//  A] Libraries
using System.Linq; //<?>

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Stores;
using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Domain.Models.Components.Toppings;

/// <summary>
/// handles database interactions
/// </summary>
namespace PizzaBox.Storage
{
  /// <summary>
  /// contains the database sets.
  /// </summary>
  public class PizzaBoxContext02 : DbContext
  {
    private readonly IConfiguration _config;

    public DbSet<Customer> Customers { get; set; }
    public DbSet<APizzaStore> Stores { get; set; }

    public DbSet<PizzaSize> Sizes { get; set; }
    public DbSet<PizzaCrust> Crusts { get; set; }
    public DbSet<PizzaSauce> Sauces { get; set; }
    public DbSet<PizzaToppingCheese> Cheeses { get; set; }
    public DbSet<APizzaTopping> Toppings { get; set; }
    public DbSet<PizzaSpice> Spices { get; set; }

    public DbSet<APizza> Pizzas { get; set; }
    public DbSet<PizzaOrder> Orders { get; set; }


    /// a parameterless blank constructor
    //public PizzaBoxContext02(){}
    public PizzaBoxContext02(DbContextOptions options) : base(options) { }


    // [II]. BODY
    //  A] Create
    /// <summary> </summary>
    /// <param name="builder"></param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<PizzaSize>().HasKey(e => e.EntityId);
      builder.Entity<PizzaCrust>().HasKey(e => e.EntityId);
      builder.Entity<PizzaSauce>().HasKey(e => e.EntityId);

      builder.Entity<APizzaTopping>().HasKey(e => e.EntityId);
      builder.Entity<PizzaToppingCheese>().HasBaseType<APizzaTopping>();
      builder.Entity<PizzaToppingVegetable>().HasBaseType<APizzaTopping>();
      builder.Entity<PizzaToppingMeat>().HasBaseType<APizzaTopping>();
      builder.Entity<PizzaToppingFruit>().HasBaseType<APizzaTopping>();
      builder.Entity<PizzaToppingMiscelaneous>().HasBaseType<APizzaTopping>();

      builder.Entity<APizza>().HasKey(e => e.EntityId);
      builder.Entity<Customer>().HasKey(e => e.EntityId);
      builder.Entity<PizzaOrder>().HasKey(e => e.EntityId);

      OnModelSeeding(builder);
    }// /md '..Creating'

    //  B] Seed
    /// <summary> </summary>
    /// <param name="builder"></param>
    private void OnModelSeeding(ModelBuilder builder)
    {
      builder.Entity<PizzaSize>().HasData(new[]
       {
        new PizzaCrust(1) { EntityId = 1, Name = "small" },
        new PizzaCrust(3) { EntityId = 3, Name = "medium" },
        new PizzaCrust(4) { EntityId = 4, Name = "large"}
      });
      builder.Entity<PizzaCrust>().HasData(new[]
      {
        new PizzaCrust(0) { EntityId = 1, Name = "crustless" },
        new PizzaCrust(1) { EntityId = 1, Name = "thin" },
        new PizzaCrust(2) { EntityId = 2, Name = "flatbread" },
        new PizzaCrust(5) { EntityId = 5, Name = "stuffed" },
      });
      builder.Entity<PizzaSauce>().HasData(new[]
{
        new PizzaSauce(0) { EntityId = 0, Name = "no" },
        new PizzaSauce(1) { EntityId = 1, Name = "catalina" },
        new PizzaSauce(2) { EntityId = 2, Name = "neopolitan" },
        new PizzaSauce(4) { EntityId = 5, Name = "nacho" },
      });
      builder.Entity<PizzaToppingCheese>().HasData(new[]
      {
        new PizzaToppingCheese(1) { EntityId = 1, Name = "mozzerella" },
        new PizzaToppingCheese(2) { EntityId = 2, Name = "mozz prov mix" },
        new PizzaToppingCheese(3) { EntityId = 3, Name = "provolone" },
        new PizzaToppingCheese(5) { EntityId = 5, Name = "gorgonzolla" },
      });

      builder.Entity<APizzaTopping>().HasData(new[]
      {
        new PizzaToppingMeat("pepperoni") { EntityId = 1, Name = "pepperoni" } as APizzaTopping,
        new PizzaToppingFruit("pineapple") { EntityId = 2, Name = "pineapple" } as APizzaTopping,
        new PizzaToppingMeat("ham") { EntityId = 3, Name = "ham" } as APizzaTopping,
        new PizzaToppingVegetable(4) { EntityId = 4, Name = "green peppers" } as APizzaTopping,
        new PizzaToppingVegetable("olives") { EntityId = 5, Name = "olives" } as APizzaTopping
      });
    }// /md 'OnModelSeeding'

    // <...> relationships

  }// /cla 'PizzaBoxContext
}// /ns '..Storage'
 // EoF