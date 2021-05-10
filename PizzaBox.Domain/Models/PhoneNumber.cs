using System;
//using System.Console;
using System.Text;

namespace PizzaBox.Domain.Abstracts
{

  public class PhoneNumber
  {
    private int _countryCode = 1; //USA
    private int _areaCode; // 3 digits
    private int _districtCode; // 3 digits
    private int _index; // 4 digits

    //  B] Constructs
    /*
    public PhoneNumber()
    {
        System.Console.Write("New Phone Number: ");
        string s = System.Console.ReadLine();
        // chain to below
    }// */
    public PhoneNumber(string s)
    {
      // Remove any dashes or whitespace.
      s = s.Replace('-', '\0').Replace(' ', '\0').Replace('\t', '\0');
      int n;
      bool didParse = int.TryParse(s, out n);
      if (didParse) { }//chain to below
      else ReportInvalidPhoneNumber();
    }

    private void ReportInvalidPhoneNumber()
    {
      System.Console.WriteLine("The phone number is not valid.");
    }

    public PhoneNumber(int n)
    {
      // Seperate the pieces.
    }

    public override string ToString()
    {
      string s = "";
      //Add the hyphens.
      return s;
    }
  }// /cla
}// /ns