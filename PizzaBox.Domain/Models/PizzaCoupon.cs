// [I]. HEAD
//  A] Libraries
using System.Text;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class PizzaCoupon : ACoupon
  {

    public override string ToString()
    {
      DetermineDiscountType();
      return $"PizzaBoz coupon #{Id}: {DiscountMessage} {DiscountedWare}.";
    }
  }// /cla 'PizzaCoupon'
}// /ns '..Models'
 // EoF