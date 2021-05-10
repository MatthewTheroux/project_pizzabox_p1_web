// [I]. HEAD
//  A] Libraries
using System; // for enum
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using PizzaBox.Domain.Abstracts;

using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Stores;
using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Domain.Models.Components.Toppings;

///
namespace PizzaBox.Storage
{
  public class PizzaBoxContext : DbContext
  {
    //  B] Properties
    private const int INDEX_FOR_UNSUPPORTED = 86;
    public DbSet<APizza> Pizzas { get; set; }

    public DbSet<PizzaSize> Sizes { get; set; }
    public DbSet<PizzaCrust> Crusts { get; set; }
    public DbSet<PizzaSauce> Sauces { get; set; }
    public DbSet<PizzaToppingCheese> Cheeses { get; set; }
    public DbSet<APizzaTopping> Toppings { get; set; }
    public DbSet<PizzaSpice> Spices { get; set; }

    public DbSet<PizzaOrder> Orders { get; set; }
    public DbSet<APizzaStore> Stores { get; set; }

    public DbSet<PizzaStoreOwner> Owners { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<PizzaCoupon> Coupons { get; set; }

    //  C]
    ///
    private readonly IConfiguration _configuration;
    //public PizzaBoxContext(){_configuration = IConfigurationBuilder.Instance().AddUserSecrets<PizzaBoxContext>().Build();}

    public PizzaBoxContext(DbContextOptions options) : base(options) { }


    // [II]. BODY
    /// 
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer(_configuration["mssql"]);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      EstablishEntities(builder);
      EstablishRelationships(builder);
      SeedInitialData(builder);
    }

    ///
    private void EstablishEntities(ModelBuilder builder)
    {
      EstablishPizzas(builder);
      EstablishComponents(builder);
      EstablishOrders(builder);
      EstablishStores(builder);
      EstablishOwners(builder);
      EstablishCustomers(builder);
      EstablishCoupons(builder);
    }

    ///
    private void EstablishPizzas(ModelBuilder builder)
    {
      builder.Entity<APizza>().HasKey(e => e.EntityId);
      builder.Entity<CheesePizza>().HasBaseType<APizza>();
      builder.Entity<PepperoniPizza>().HasBaseType<APizza>();
      builder.Entity<VegetablePizza>().HasBaseType<APizza>();
      builder.Entity<MeatPizza>().HasBaseType<APizza>();
      builder.Entity<CustomPizza>().HasBaseType<APizza>();
    }// /ax 'EstablishPizzas'

    ///
    private void EstablishComponents(ModelBuilder builder)
    {
      builder.Entity<PizzaSize>().HasKey(e => e.EntityId);
      builder.Entity<PizzaCrust>().HasKey(e => e.EntityId);
      builder.Entity<PizzaSauce>().HasKey(e => e.EntityId);
      EstablishToppings(builder);
      builder.Entity<PizzaSpice>().HasKey(e => e.EntityId);
    }// /ax 'EstablishComponents'

    ///
    private void EstablishToppings(ModelBuilder builder)
    {
      builder.Entity<APizzaTopping>().HasKey(e => e.EntityId);
      builder.Entity<PizzaToppingCheese>().HasBaseType<APizzaTopping>();
      builder.Entity<PizzaToppingVegetable>().HasBaseType<APizzaTopping>();
      builder.Entity<PizzaToppingMeat>().HasBaseType<APizzaTopping>();
      builder.Entity<PizzaToppingFruit>().HasBaseType<APizzaTopping>();
      builder.Entity<PizzaToppingMiscelaneous>().HasBaseType<APizzaTopping>();
    }// /ax 'EstablishToppings'

    private void EstablishOrders(ModelBuilder builder)
    {
      builder.Entity<PizzaOrder>().HasKey(e => e.EntityId);
    }// /ax 'EstablishOrders'

    ///
    private void EstablishStores(ModelBuilder builder)
    {
      builder.Entity<APizzaStore>().HasKey(e => e.EntityId);
      builder.Entity<FamilyPizzaStore>().HasBaseType<APizzaStore>();
      builder.Entity<ExpressPizzaStore>().HasBaseType<APizzaStore>();
    }// /ax 'EstablishStores'

    ///
    private void EstablishOwners(ModelBuilder builder)
    {
      builder.Entity<PizzaStoreOwner>().HasKey(e => e.EntityId);
    }// /ax 'EstablishOwners'

    private void EstablishCustomers(ModelBuilder builder)
    {
      builder.Entity<Customer>().HasKey(e => e.EntityId);
    }// /ax 'EstablishCustomers'

    private void EstablishCoupons(ModelBuilder builder)
    {
      builder.Entity<PizzaCoupon>().HasKey(e => e.EntityId);
    }// /ax 'EstablishCustomers'

    //  B]
    ///
    private void EstablishRelationships(ModelBuilder builder)
    {
      builder.Entity<APizzaStore>().HasMany<PizzaOrder>(store => store.Orders).WithOne(order => order.Store);
      builder.Entity<PizzaOrder>().HasMany<APizza>(order => order.Pizzas).WithOne(pizza => pizza.Order);
      builder.Entity<APizza>().HasMany<APizzaTopping>(pizza => pizza.Toppings).WithOne(topping => topping.Pizza);
      builder.Entity<Customer>().HasMany<PizzaOrder>(customer => customer.Orders).WithOne(order => order.Customer);
      builder.Entity<Customer>().HasMany<PizzaCoupon>(customer => customer.Coupons).WithOne(coupon => coupon.Customer);
    }// /ax 'EstablishRelationships


    //  C]
    /// the initial seed data for the enitity tables
    private void SeedInitialData(ModelBuilder builder)
    {
      SeedPizzas(builder);
      SeedComponents(builder);
      SeedOrders(builder);
      SeedStores(builder);
      SeedOwners(builder);
      SeedCustomers(builder);
    }// /ax 'SeedInitalData'


    private void SeedPizzas(ModelBuilder builder)
    {
      builder.Entity<APizza>().HasData(new APizza[]
      {
        new CheesePizza() {EntityId = 3},
        new PepperoniPizza(){EntityId=1},
        new VegetablePizza() {EntityId=4},
        new MeatPizza(){EntityId=5},
        //new DeluxePizza(){EntityId=7}
      });
    }// /ax 'SeedPizzas'

    ///
    private void SeedComponents(ModelBuilder builder)
    {
      SeedCrusts(builder);
      SeedSauces(builder);
      SeedToppings(builder);
      SeedSpices(builder);
    }

    private void SeedCrusts(ModelBuilder builder)
    {
      //  a) head
      List<PizzaCrust> crusts = new List<PizzaCrust>();

      //  b) body
      foreach (int index in Enum.GetValues(typeof(PizzaCrust.Choice)))
      {
        if (index == INDEX_FOR_UNSUPPORTED) continue;

        PizzaCrust crust = new PizzaCrust(index);
        crust.EntityId = index;
        crusts.Add(crust);
      }// next crust 'index'

      //  c) foot
      /// Add the crust choices collection to the context.
      builder.Entity<PizzaSauce>().HasData(crusts.ToArray());
    }// /ax 'SeedCrusts'

    /// <summary> Seed the values for pizza sauces. </summary>
    private void SeedSauces(ModelBuilder builder)
    {
      //  a) head
      List<PizzaSauce> sauces = new List<PizzaSauce>();

      //  b) body
      foreach (int index in Enum.GetValues(typeof(PizzaSauce.Choice)))
      {
        if (index == INDEX_FOR_UNSUPPORTED) continue;

        PizzaSauce sauce = new PizzaSauce(index);
        sauce.EntityId = index;
        sauces.Add(sauce);
      }// next sauce 'index'

      //  c) foot
      /// Add sauce choices collection to the context.
      builder.Entity<PizzaSauce>().HasData(sauces.ToArray());
    }// /ax 'SeedSauces'

    /// <summary> Seed the values for pizza cheeses. </summary>
    private void SeedCheeses(ModelBuilder builder)
    {
      //  a) head
      List<PizzaToppingCheese> cheeses = new List<PizzaToppingCheese>();

      //  b) body
      foreach (int index in Enum.GetValues(typeof(PizzaToppingCheese.Choice)))
      {
        if (index == INDEX_FOR_UNSUPPORTED) continue;

        PizzaToppingCheese cheese = new PizzaToppingCheese(index);
        cheese.EntityId = index;
        cheeses.Add(cheese);
      }// next cheese 'index'

      //  c) foot
      /// Add the cheese choices collection to the context.
      builder.Entity<PizzaToppingCheese>().HasData(cheeses.ToArray());
    }// /ax 'SeedCheeses'

    private void SeedToppings(ModelBuilder builder)
    {
      SeedCheeses(builder);
      SeedVegetables(builder);
      SeedMeats(builder);
      SeedFruits(builder);
      SeedMiscelanous(builder);
    }

    /// <summary> Seed the values for pizza vegetables. </summary>
    private void SeedVegetables(ModelBuilder builder)
    {
      //  a) head
      List<PizzaToppingVegetable> vegetables = new List<PizzaToppingVegetable>();

      //  b) body
      foreach (int index in Enum.GetValues(typeof(PizzaToppingVegetable.Choice)))
      {
        if (index < 1) continue;
        if (index == INDEX_FOR_UNSUPPORTED) continue;

        vegetables.Add(new PizzaToppingVegetable(index));
      }// next vegetable 'index'

      //  c) foot
      /// Add the collection of vegetable choices to the context.
      builder.Entity<PizzaToppingVegetable>().HasData(vegetables.ToArray<PizzaToppingVegetable>());
    }// /ax 'SeedVegetables'

    /// <summary> Seed the values for pizza meats. </summary>
    private void SeedMeats(ModelBuilder builder)
    {
      //  a) head
      List<PizzaToppingMeat> meats = new List<PizzaToppingMeat>();

      //  b) body
      foreach (int index in Enum.GetValues(typeof(PizzaToppingMeat.Choice)))
      {
        if (index < 1) continue;
        if (index == INDEX_FOR_UNSUPPORTED) continue;

        meats.Add(new PizzaToppingMeat(index));
      }// next meat 'index' 

      //  c) foot
      /// Add the collection of meat choices to the context.
      builder.Entity<PizzaToppingMeat>().HasData(meats.ToArray<PizzaToppingMeat>());
    }// /ax 'SeedMeats'

    /// <summary> Seed the values for pizza fruits. </summary>
    private void SeedFruits(ModelBuilder builder)
    {
      //  a) head
      List<PizzaToppingFruit> fruits = new List<PizzaToppingFruit>();

      //  b) body
      foreach (int index in Enum.GetValues(typeof(PizzaToppingFruit.Choice)))
      {
        if (index < 1) continue;
        if (index == INDEX_FOR_UNSUPPORTED) continue;

        fruits.Add(new PizzaToppingFruit(index));
      }// next fruit 'index'

      //  c) foot
      /// Add the collection of fruit choices to the context.
      builder.Entity<PizzaToppingFruit>().HasData(fruits.ToArray<PizzaToppingFruit>());
    }// /ax 'SeedFruits'

    /// <summary> Seed the values for pizza fruits. </summary>
    private void SeedMiscelanous(ModelBuilder builder)
    {
      //  a) head
      List<PizzaToppingMiscelaneous> items = new List<PizzaToppingMiscelaneous>();

      //  b) body
      foreach (int index in Enum.GetValues(typeof(PizzaToppingMiscelaneous.Choice)))
      {
        if (index < 1) continue;
        if (index == INDEX_FOR_UNSUPPORTED) continue;

        items.Add(new PizzaToppingMiscelaneous(index));
      }// next fruit 'index'

      //  c) foot
      /// Add the collection of fruit choices to the context.
      builder.Entity<PizzaToppingMiscelaneous>().HasData(items.ToArray<PizzaToppingMiscelaneous>());
    }// /ax 'SeedFruits'
     //........................................................................

    /// <summary> Seed the values for pizza spices. </summary>
    private void SeedSpices(ModelBuilder builder)
    {
      //  a) head
      List<PizzaSpice> spices = new List<PizzaSpice>();

      //  b) body
      foreach (int index in Enum.GetValues(typeof(PizzaSpice.Choice)))
      {
        if (index == INDEX_FOR_UNSUPPORTED) continue;

        PizzaSpice spice = new PizzaSpice(index);
        spice.EntityId = index;
        spices.Add(spice);
      }// next 'index'

      //  c) foot
      /// Add the collection of spice choices to the context.
      builder.Entity<PizzaSpice>().HasData(spices.ToArray());
    }// /ax 'SeedSpices'
     //------------------------------------------------------------------------

    /// 
    private void SeedOrders(ModelBuilder builder)
    {
      builder.Entity<PizzaOrder>().HasData(new PizzaOrder[] { });
    }// /ax 'SeedOrders'

    ///
    private void SeedStores(ModelBuilder builder)
    {
      builder.Entity<ExpressPizzaStore>().HasData(new ExpressPizzaStore[]
      {
        new ExpressPizzaStore() {EntityId = 1, Name = "Dominos"},
        new ExpressPizzaStore() {EntityId = 2, Name = "ModPizza"},
        new ExpressPizzaStore() {EntityId = 3, Name = "Subway"}
      });

      builder.Entity<FamilyPizzaStore>().HasData(new FamilyPizzaStore[]
      {
        new FamilyPizzaStore() {EntityId = 1, Name = "Pizza Hut"},
        new FamilyPizzaStore() {EntityId = 2, Name = "Tony's"},
        new FamilyPizzaStore() {EntityId = 3, Name = "Pizzapopolis"}
      });
    }// /ax 'SeedStores'

    private void SeedOwners(ModelBuilder builder)
    {
      builder.Entity<PizzaStoreOwner>().HasData(new PizzaStoreOwner[]
      {
          new PizzaStoreOwner() {EntityId = 1, Name = "Jackie Noid"},
          new PizzaStoreOwner() {EntityId = 2, Name = "Tom Tesla"},
          new PizzaStoreOwner() {EntityId = 3, Name = "Jared Cooper"},

          new PizzaStoreOwner() {EntityId = 4, Name = "Jared Cooper"},
          new PizzaStoreOwner() {EntityId = 5, Name = "Tony Phatt"},
          new PizzaStoreOwner() {EntityId = 6, Name = "Chicago Pete"}
      });
    }// /ax 'SeedOwners'

    /// <summary> Seed the customer data </summary>
    private void SeedCustomers(ModelBuilder builder)
    {
      builder.Entity<Customer>().HasData(new Customer[]
     {
        new Customer() { EntityId = 1, Name = "Uncle John" },
        new Customer() { EntityId = 2, Name = "Uncle Buck" },
        new Customer() { EntityId = 3, Name = "Bartholomew Mog" }
     });
    }// /ax 'SeedCustomers'

    /// <summary> </summary>
    private void SeedCoupons(ModelBuilder builder)
    {
      builder.Entity<PizzaCoupon>().HasData(new PizzaCoupon[]
      {
        new PizzaCoupon() { EntityId = 1, Id=939934071,
          DiscountedWare = new PepperoniPizza()
          {
            Size = new PizzaSize(PizzaSize.Choice.LARGE)
          },
          AmountOff = 2, // = -$2
        },// /cpn

          new PizzaCoupon() { EntityId = 1, Id=533791774,
          DiscountedWare = new PepperoniPizza()
          {
            Size = new PizzaSize(PizzaSize.Choice.SHEET)
          },
          AmountOff = 5, // = -$5
        }// /cpn
      });
    }// /ax 'SeedCoupons'

  }// /cla 'PizzaBoxContext'
}// /ns '..Storage'
 // EoF