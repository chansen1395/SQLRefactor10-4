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

    [TestMethod]
    public void GetAll_ReturnsAllVendorObjects_VendorList()
    {
      string vendorName01 = "Steve's Pizzaria";
      string vendorName02 = "Dan's Dough";
      Vendor newVendor1 = new Vendor(vendorName01);
      Vendor newVendor2 = new Vendor(vendorName02);
      List<Vendor> newList = new List<Vendor> { newVendor1, newVendor2 };

      List<Vendor> result = Vendor.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectVendor_Vendor()
    {
      //Arrange
      string vendorName01 = "Stan's Spaghetteria";
      string vendorName02 = "Allen's Artisinal Breads";
      Vendor newVendor1 = new Vendor(vendorName01);
      Vendor newVendor2 = new Vendor(vendorName02);

      //Act
      Vendor result = Vendor.Find(2);

      //Assert
      Assert.AreEqual(newVendor2, result);
    }
  }
}