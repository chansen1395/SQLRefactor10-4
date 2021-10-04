using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace VendorTracker.Models
{
  public class Order
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public DateTime OrderDate { get; set; }
    public bool Paid { get; set; }
    public int Id { get; set; }
    private static List<Order> _instances = new List<Order> { };

    public Order(string title, string description, double price, DateTime orderDate, bool paid)
    {
      Title = title;
      Description = description;
      Price = price;
      OrderDate = orderDate;
      Paid = paid;
    }

    public Order(string title, string description, double price, DateTime orderDate, bool paid, int id)
    {
      Title = title;
      Description = description;
      Price = price;
      OrderDate = orderDate;
      Paid = paid;
      Id = id;
    }

    public static List<Order> GetAll()
    {
      List<Order> allOrders = new List<Order> { };
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM bakery_orders;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
          int orderId = rdr.GetInt32(0);
          string orderTitle = rdr.GetString(1);
          string orderDescription = rdr.GetString(2);
          // Unable to cast object of type 'System.DBNull' to type 'System.Double'.
          // double orderPrice = rdr.GetDouble(3);
          double orderPrice = 10;
          DateTime orderDate = rdr.GetDateTime(4);
          Console.WriteLine(orderDate);
          bool orderPaid = rdr.GetBoolean(5);
          Console.WriteLine(orderPaid);
          Order newOrder = new Order(orderTitle, orderDescription, orderPrice, orderDate, orderPaid, orderId);
          allOrders.Add(newOrder);
      }
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      return allOrders;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM bakery_orders;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public override bool Equals(System.Object otherOrder)
    {
      if (!(otherOrder is Order))
      {
        return false;
      }
      else
      {
        Order newOrder = (Order) otherOrder;
        bool descriptionEquality = (this.Description == newOrder.Description);
        return descriptionEquality;
      }
    }


    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;

      // Begin new code

      cmd.CommandText = @"INSERT INTO bakery_orders (order_title, order_description, order_price, order_date, order_paid)
        VALUES (@OrderTitle, @OrderDescription, @OrderPrice, @OrderDate, @OrderPaid);";
      MySqlParameter order_title = new MySqlParameter();
      MySqlParameter order_description = new MySqlParameter();
      MySqlParameter order_price = new MySqlParameter();
      MySqlParameter order_date = new MySqlParameter();
      MySqlParameter order_paid = new MySqlParameter();
      order_title.ParameterName = "@OrderTitle";
      order_description.ParameterName = "@OrderDescription";
      order_price.ParameterName = "@OrderPrice";
      order_date.ParameterName = "@OrderDate";
      order_price.ParameterName = "@OrderPaid";
      order_title.Value = this.Title;
      order_description.Value = this.Description;
      order_price.Value = this.Price;
      order_date.Value = this.OrderDate;
      order_paid.Value = this.Paid;
      cmd.Parameters.Add(order_title);    
      cmd.Parameters.Add(order_description);    
      cmd.Parameters.Add(order_price);    
      cmd.Parameters.Add(order_date);    
      cmd.Parameters.Add(order_paid);    
      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;

      // End new code

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    // public static Order Find(int searchId)
    // {
    // Order placeholderOrder = new Order("placeholder order");
    // return placeholderOrder;
    // }

    // public static Order UpdatePaid(int paidId)
    // {
    //   if (_instances[paidId].Paid)
    //   {
    //     _instances[paidId].Paid = false;
    //     return _instances[paidId];
    //   }
    //   else
    //   {
    //     _instances[paidId].Paid = true;
    //     return _instances[paidId];
    //   }
    // }

    // ** WIP **
    // public void CancelOrder(int orderId)
    // {
    //   Order.RemoveAt(orderId);
    // }
    // ** END WIP **
  }
}