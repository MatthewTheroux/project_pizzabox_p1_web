// [I]. HEAD
//  A] Libraries
using System;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
  public abstract class ACoupon : AnEntity
  {
    //  B] Properties / Attributes
    public int Id { get; set; } //semi-unique
    public DateTime ExperationDate { get; set; }
    public AWare DiscountedWare { get; set; }


    public string DiscountType { get; set; } = "Advertisement";
    public string DiscountMessage { get; set; } = "Ad for";

    /// Get __ $amount off the ware, e.g., $1.00 off.
    public decimal AmountOff { get; set; }

    /// Get __ % off the ware, e.g., 20% off)
    public decimal PercentOff { get; set; }

    ///
    public Price NewPrice { get; set; }


    // D]
    /// the holder of the coupon
    public Customer Customer { get; set; }


    // [II]. BODY
    ///
    public void DetermineDiscountType()
    {
      if (AmountOff > 0)
      {
        DiscountType = "Amount Off";
        DiscountMessage = $"${AmountOff} off of";
      }
      else
      if (PercentOff > 0)
      {
        DiscountType = "PercentOff";
        DiscountMessage = $"{PercentOff * 100}% off of";
      }// /cs  discount type
    }// /md 'DetermineDiscountType'


    // [III]. FOOT
    public abstract override string ToString();
  }// /cla 'ACoupon'
}// /ns '..Abstracts'
 // EoF