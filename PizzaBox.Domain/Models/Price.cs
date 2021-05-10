using System;


namespace PizzaBox.Domain.Models
{
  public class Price
  {
    public decimal Amount { get; set; } = 0.00M;
    public string Currency { get; private set; } = "USD"; // =$

    public decimal SalesTaxRate { get; private set; } = .07M; // = 07% default

    public decimal SalesTax { get { return Amount * SalesTaxRate; } }
    public decimal WithTax { get { return Amount + SalesTax; } }

    // [II].BODY
    /// constructor | blank constructor with defaults
    public Price(decimal _amt = 0M, string _curr = "USD")
    {
      Amount = (decimal)_amt;
      Currency = _curr;
    }

    /// Set and return the new sales tax rate.
    public decimal SetSalesTaxRate(decimal _rate) { return SalesTaxRate = _rate; }


    // [III]. FOOT
    ///
    public string As2Decimal(decimal _amt)
    {
      //double _result = 0;
      string _amtStringFormattedto2DecimalPlaces = String.Format("{0:C2}", _amt);
      //double.TryParse(_amtStringFormattedto2DecimalPlaces, out _result);
      //return _result;
      return _amtStringFormattedto2DecimalPlaces;
    }// /md 'As2Decimal'

    /// 
    public override string ToString()
    {
      return $"{As2Decimal(Amount)} {Currency}";
    }
  }// /cla
}// /ns
 // EoF