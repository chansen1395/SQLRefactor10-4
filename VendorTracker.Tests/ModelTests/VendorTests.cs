using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendorTracker.Models;
using System.Collections.Generic;
using System;

namespace VendorTracker.Tests
{
  [TestClass]
  public class VendorsTests : IDisposable
  {
  
    public void Dispose()
    {
      Vendor.ClearAll();
    }
 
    [TestMethod]
    public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
    {
      Vendor newVendor = new Vendor("test vendor");
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }

    [TestMethod]
    public void GetVendor_ReturnsVendor_String()
    {
      string vendorName = "Bobby's Pie Shop";
      Vendor newVendor = new Vendor(vendorName);

      string result = newVendor.VendorName;

      Assert.AreEqual(vendorName, result);
    }

    [TestMethod]
    public void SetVendor_ReturnsVendor_String()
    {
      string vendorName = "Bobby's Pie Shop";
      string newVendorName = "Joe's Cakery";
      Vendor newVendor = new Vendor(vendorName);

      newVendor.VendorName = newVendorName;

      Assert.AreEqual(newVendor.VendorName, newVendorName);
    }

    [TestMethod]
    public void GetId_ReturnsVendorsId_Int()
    {
      string vendorName = "Test Vendors";
      Vendor newVendors = new Vendor(vendorName);

      int result = newVendors.Id;

      Assert.AreEqual(1, result);
    }
  }
}