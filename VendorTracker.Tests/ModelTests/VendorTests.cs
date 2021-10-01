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
      Vendor newVendor = new Vendor("test vendor", "test description");
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }

    [TestMethod]
    public void GetVendor_ReturnsVendor_String()
    {
      string vendorName = "Bobby's Pie Shop";
      string vendorDescription = "123 Main St.";
      Vendor newVendor = new Vendor(vendorName, vendorDescription);

      string result = newVendor.VendorName;

      Assert.AreEqual(vendorName, result);
    }

    [TestMethod]
    public void SetVendor_ReturnsVendor_String()
    {
      string vendorName = "Bobby's Pie Shop";
      string newVendorName = "Joe's Cakery";
      string vendorDescription = "123 Main St.";
      Vendor newVendor = new Vendor(vendorName, vendorDescription);

      newVendor.VendorName = newVendorName;

      Assert.AreEqual(newVendor.VendorName, newVendorName);
    }

    [TestMethod]
    public void GetId_ReturnsVendorsId_Int()
    {
      string vendorName = "Test Vendors";
      string vendorDescription = "Test Description";
      Vendor newVendor = new Vendor(vendorName, vendorDescription);

      int result = newVendor.Id;

      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllVendorObjects_VendorList()
    {
      string vendorName01 = "Steve's Pizzaria";
      string vendorDescription01 = "Test Description1";
      string vendorName02 = "Dan's Dough";
      string vendorDescription02 = "Test Description2";
      Vendor newVendor1 = new Vendor(vendorName01, vendorDescription01);
      Vendor newVendor2 = new Vendor(vendorName02, vendorDescription02);
      List<Vendor> newList = new List<Vendor> { newVendor1, newVendor2 };

      List<Vendor> result = Vendor.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectVendor_Vendor()
    {
      string vendorName01 = "Stan's Spaghetteria";
      string vendorDescription01 = "Test Description1";
      string vendorName02 = "Allen's Artisinal Breads";
      string vendorDescription02 = "Test Description2";
      Vendor newVendor1 = new Vendor(vendorName01, vendorDescription01);
      Vendor newVendor2 = new Vendor(vendorName02, vendorDescription02);

      Vendor result = Vendor.Find(2);

      Assert.AreEqual(newVendor2, result);
    }

    [TestMethod]
    public void AddOrder_AssociatesOrderWithVendor_OrderList()
    {
      string title = "Pastry Order";
      string description = "8 Pastries";
      int price = 17;
      string date = "06-01-2015";
      Order newOrder = new Order(title, description, price, date);
      List<Order> newList = new List<Order> { newOrder };
      string vendorName = "Bob";
      string vendorDescription = "456 Main St.";
      Vendor newVendor = new Vendor(vendorName, vendorDescription);
      newVendor.AddOrder(newOrder);

      List<Order> result = newVendor.Orders;

      CollectionAssert.AreEqual(newList, result);
    }
  }
}