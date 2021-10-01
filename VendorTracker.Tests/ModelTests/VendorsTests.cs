using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendorTracker.Models;
using System.Collections.Generic;
using System;

namespace VendorTracker.Tests
{
  [TestClass]
  public class VendorsTests
  
  // public void Dispose()
  // {
  //   Vendors.ClearAll();
  // }
 
  {
    [TestMethod]
    public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
    {
      Vendors newVendor = new Vendors("test vendor");
      Assert.AreEqual(typeof(Vendors), newVendor.GetType());
    }

    [TestMethod]
    public void GetVendor_ReturnsVendor_String()
    {
      string vendorName = "Bobby's Pie Shop";
      Vendors newVendor = new Vendors(vendorName);

      string result = newVendor.VendorName;

      Assert.AreEqual(vendorName, result);
    }

    [TestMethod]
    public void SetVendor_ReturnsVendor_String()
    {
      string vendorName = "Bobby's Pie Shop";
      string newVendorName = "Joe's Cakery";
      Vendors newVendor = new Vendors(vendorName);

      newVendor.VendorName = newVendorName;

      Assert.AreEqual(newVendor.VendorName, newVendorName);
    }
  }
}