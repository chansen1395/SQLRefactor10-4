using System.Collections.Generic;

namespace VendorTracker.Models
{
  public class Vendors
  {
    public string VendorName { get; set; }

    public Vendors(string vendorName)
    {
      VendorName = vendorName;
    }

  }
}