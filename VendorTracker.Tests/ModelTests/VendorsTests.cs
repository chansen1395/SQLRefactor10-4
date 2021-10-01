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
      Vendors newVendor = new Vendors();
      Assert.AreEqual(typeof(Vendors), newVendor.GetType());
    }
  }
}