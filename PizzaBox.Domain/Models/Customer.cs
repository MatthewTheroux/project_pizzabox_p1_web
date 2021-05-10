// [I]. HEAD
//  A] usings
using System; // for enum
using System.Collections.Generic;


using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  /// <summary>
  /// one who potentially purchases wares
  /// </summary>
  public class Customer : AnEntity
  {
    //  B] Properties
    public string Prefix { get; private set; } = "";
    public string FirstName { get; private set; } = "";
    public string LastName { get; private set; } = "";

    public string Suffix { get; private set; } = "";

    public string FullName { get { return $"{Prefix} {FirstName} {LastName}, {Suffix}"; } }

    public new string Name { get; set; } = "";

    public PhoneNumber PhoneNumber { get; set; }
    public Address Address { get; set; }
    //[] constrict
    public string Email { get; private set; }

    //  C] enums
    private enum PrefixChoice { Mr, Miss, Ms, Mrs, Dr }
    private enum SuffixChoice { Sr, Jr, I, II, III, IV }

    //  D]
    public List<PizzaOrder> Orders { get; set; }
    public List<PizzaCoupon> Coupons { get; set; }


    // [II]. BODY 
    public Customer(string name = null) { Name = name; }
    public Customer(Customer customer) : this(customer.Name) { }


    // [III]. FOOT
    public override string ToString() { return Name; }

  }// /cla 'Customer'
}// /ns '..Models' 
 // EoF