using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendorTracker.Models;
using System.Collections.Generic;
using System;

namespace VendorTracker.Tests
{
  [TestClass]
  public class OrdersTests : IDisposable
  {
  
    public void Dispose()
    {
      Order.ClearAll();
    }
//  Order(string title, string description, int price, string date)
    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
      Order newOrder = new Order("test title", "test description", 1, "test date");
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }

    [TestMethod]
    public void GetOrder_GetOrder_String()
    {
      string title = "Bread Order";
      string description = "8 Bread";
      int price = 22;
      string orderDate = "07-15-2012";
      Order newOrder = new Order(title, description, price, orderDate);

      Assert.AreEqual(newOrder.Title, title);
      Assert.AreEqual(newOrder.Description, description);
      Assert.AreEqual(newOrder.Price, price);
      Assert.AreEqual(newOrder.OrderDate, orderDate);
    }

    [TestMethod]
    public void SetOrder_SetOrder_String()
    {
      string title = "Bread Order";
      string description = "8 Bread";
      int price = 22;
      string orderDate = "07-15-2012";
      Order newOrder = new Order(title, description, price, orderDate);

      string newTitle = "Pastry Order";
      string newDescription = "8 Pastry";
      int newPrice = 22;
      string newOrderDate = "08-01-2010";
      newOrder.Title = newTitle;
      newOrder.Description = newDescription;
      newOrder.Price = newPrice;
      newOrder.OrderDate = newOrderDate;

      Assert.AreEqual(newOrder.Title, newTitle);
      Assert.AreEqual(newOrder.Description, newDescription);
      Assert.AreEqual(newOrder.Price, newPrice);
      Assert.AreEqual(newOrder.OrderDate, newOrderDate);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_OrderList()
    {
      List<Order> newList = new List<Order> { };

      List<Order> result = Order.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllOrderObjects_OrderList()
    {
      string title01 = "Bread Order";
      string description01 = "8 Bread";
      int price01 = 22;
      string orderDate01 = "07-15-2012";
      string title02 = "Pastry Order";
      string description02 = "8 Pastry";
      int price02 = 22;
      string orderDate02 = "08-01-2010";

      Order order01 = new Order(title01, description01, price01, orderDate01);
      Order order02 = new Order(title02, description02, price02, orderDate02);
      List<Order> newList = new List<Order> { order01, order02 };

      List<Order> result = Order.GetAll();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetId_ReturnsOrderId_Int()
    {
      string title01 = "Bread Order";
      string description01 = "8 Bread";
      int price01 = 22;
      string orderDate01 = "07-15-2012";
      Order newOrder = new Order(title01, description01, price01, orderDate01);
      int result = newOrder.Id;

      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectVendor_Vendor()
    {
      string title01 = "Bread Order";
      string description01 = "8 Bread";
      int price01 = 22;
      string orderDate01 = "07-15-2012";
      string title02 = "Pastry Order";
      string description02 = "8 Pastry";
      int price02 = 22;
      string orderDate02 = "08-01-2010";

      Order order01 = new Order(title01, description01, price01, orderDate01);
      Order order02 = new Order(title02, description02, price02, orderDate02);

      Order result = Order.Find(2);

      Assert.AreEqual(order02, result);
    }
  }
}