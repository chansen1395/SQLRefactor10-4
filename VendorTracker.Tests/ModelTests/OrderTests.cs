using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendorTracker.Models;
using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace VendorTracker.Tests
{
  [TestClass]
  public class OrderTests : IDisposable
  {
  
    public void Dispose()
    {
      Order.ClearAll();
    }

    // The method below is new code.
    public OrderTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=epicodus;port=3306;database=vendor_tracker_test;Allow User Variables=True";
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_OrderList()
    {
      //Arrange
      List<Order> newList = new List<Order> { };

      //Act
      List<Order> result = Order.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Order()
    {
      // Arrange, Act
      DateTime orderDate = new DateTime(1999, 12, 31);
      DateTime orderDate2 = new DateTime(1999, 12, 31);
      Order firstOrder = new Order("title", "Mow the lawn", 12, orderDate, false);
      Order secondOrder = new Order("title", "Mow the lawn", 12, orderDate2, false);

      // Assert
      Assert.AreEqual(firstOrder, secondOrder);
    }

    [TestMethod]
    public void Save_SavesToDatabase_OrderList()
    {
      //Arrange
      double price = 10.5;
      DateTime orderDate = new DateTime(1999, 12, 31);
      Order testOrder = new Order("title2", "Mow the lawn7", price, orderDate, false);

      //Act
      testOrder.Save();
      List<Order> result = Order.GetAll();
      List<Order> testList = new List<Order>{testOrder};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

// //  Order(string title, string description, int price, string date)
//     [TestMethod]
//     public void OrderConstructor_CreatesInstanceOfOrder_Order()
//     {
//       Order newOrder = new Order("test title", "test description", 1, "test date", false);
//       Assert.AreEqual(typeof(Order), newOrder.GetType());
//     }

//     [TestMethod]
//     public void GetOrder_GetOrder_String()
//     {
//       string title = "Bread Order";
//       string description = "8 Bread";
//       int price = 22;
//       string orderDate = "07-15-2012";
//       Order newOrder = new Order(title, description, price, orderDate, false);

//       Assert.AreEqual(newOrder.Title, title);
//       Assert.AreEqual(newOrder.Description, description);
//       Assert.AreEqual(newOrder.Price, price);
//       Assert.AreEqual(newOrder.OrderDate, orderDate);
//     }

//     [TestMethod]
//     public void SetOrder_SetOrder_String()
//     {
//       string title = "Bread Order";
//       string description = "8 Bread";
//       int price = 22;
//       string orderDate = "07-15-2012";
//       bool paid = false;
//       Order newOrder = new Order(title, description, price, orderDate, paid);

//       string newTitle = "Pastry Order";
//       string newDescription = "8 Pastry";
//       int newPrice = 22;
//       string newOrderDate = "08-01-2010";
//       bool newPaid = true;
//       newOrder.Title = newTitle;
//       newOrder.Description = newDescription;
//       newOrder.Price = newPrice;
//       newOrder.OrderDate = newOrderDate;
//       newOrder.Paid = newPaid;

//       Assert.AreEqual(newOrder.Title, newTitle);
//       Assert.AreEqual(newOrder.Description, newDescription);
//       Assert.AreEqual(newOrder.Price, newPrice);
//       Assert.AreEqual(newOrder.OrderDate, newOrderDate);
//       Assert.AreEqual(newOrder.Paid, newPaid);
//     }

//     [TestMethod]
//     public void GetAll_ReturnsEmptyList_OrderList()
//     {
//       List<Order> newList = new List<Order> { };

//       List<Order> result = Order.GetAll();

//       CollectionAssert.AreEqual(newList, result);
//     }

//     [TestMethod]
//     public void GetAll_ReturnsAllOrderObjects_OrderList()
//     {
//       string title01 = "Bread Order";
//       string description01 = "8 Bread";
//       int price01 = 22;
//       string orderDate01 = "07-15-2012";
//       bool paid01 = true;

//       string title02 = "Pastry Order";
//       string description02 = "8 Pastry";
//       int price02 = 22;
//       string orderDate02 = "08-01-2010";
//       bool paid02 = false;

//       Order order01 = new Order(title01, description01, price01, orderDate01, paid01);
//       Order order02 = new Order(title02, description02, price02, orderDate02, paid02);
//       List<Order> newList = new List<Order> { order01, order02 };

//       List<Order> result = Order.GetAll();

//       CollectionAssert.AreEqual(newList, result);
//     }

//     [TestMethod]
//     public void GetId_ReturnsOrderId_Int()
//     {
//       string title01 = "Bread Order";
//       string description01 = "8 Bread";
//       int price01 = 22;
//       string orderDate01 = "07-15-2012";
//       bool paid01 = false;
//       Order newOrder = new Order(title01, description01, price01, orderDate01, paid01);
//       int result = newOrder.Id;

//       Assert.AreEqual(1, result);
//     }

    // [TestMethod]
    // public void Find_ReturnsCorrectVendor_Vendor()
    // {
    //   string title01 = "Bread Order";
    //   string description01 = "8 Bread";
    //   int price01 = 22;
    //   string orderDate01 = "07-15-2012";
    //   bool paid01 = true;

    //   string title02 = "Pastry Order";
    //   string description02 = "8 Pastry";
    //   int price02 = 22;
    //   string orderDate02 = "08-01-2010";
    //   bool paid02 = false;

    //   Order order01 = new Order(title01, description01, price01, orderDate01, paid01);
    //   Order order02 = new Order(title02, description02, price02, orderDate02, paid02);

    //   Order result = Order.Find(2);

    //   Assert.AreEqual(order02, result);
    // }
  }
}