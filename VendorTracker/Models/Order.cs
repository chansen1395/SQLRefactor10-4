using System;
using System.Collections.Generic;

namespace VendorTracker.Models
{
  public class Order
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string OrderDate { get; set; }
    public bool Paid { get; set; }
    public int Id { get; }
    private static List<Order> _instances = new List<Order> { };

    public Order(string title, string description, int price, string orderDate, bool paid)
    {
      Title = title;
      Description = description;
      Price = price;
      OrderDate = orderDate;
      Paid = paid;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public static List<Order> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Order Find(int searchId)
    {
      return _instances[searchId-1];
    }

    public static Order UpdatePaid(int paidId)
    {
      if (_instances[paidId - 1].Paid)
      {
        _instances[paidId -1 ].Paid = false;
        return _instances[paidId - 1];
      }
      else
      {
        _instances[paidId - 1].Paid = true;
        return _instances[paidId - 1];
      }
    }

    // ** WIP **
    // public void CancelOrder(int orderId)
    // {
    //   Order.RemoveAt(orderId);
    // }
    // ** END WIP **
  }
}