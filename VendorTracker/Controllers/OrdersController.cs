using Microsoft.AspNetCore.Mvc;
using VendorTracker.Models;
using System.Collections.Generic;

namespace VendorTracker.Controllers
{
  public class OrdersController : Controller
  {
    [HttpGet("/vendors/{vendorId}/orders/new")]
    public ActionResult New(int vendorId)
    {
      Vendor vendor = Vendor.Find(vendorId);
      return View(vendor);
    }

    [HttpPost("/orders/delete")]
    public ActionResult DeleteAll()
    {
      Order.ClearAll();
      return View();
    }

    // [HttpGet("/vendors/{vendorId}/orders/{orderId}")]
    // public ActionResult Show(int vendorId, int orderId)
    // {
    //   Order order = Order.Find(orderId);
    //   Vendor vendor = Vendor.Find(vendorId);
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   model.Add("order", order);
    //   model.Add("vendor", vendor);
    //   return View(model);
    // }

    // // WIP Currently only switches paid for first order if multiple orders are made
    // [HttpPost("/vendors/{vendorId}/orders/{orderId}/edit")]
    // public ActionResult Update(int orderId)
    // {
    //   Order paidOrder = Order.UpdatePaid(orderId);
    //   Response.Redirect("/vendors");
    //   return View();
    // }

    // *** WIP ***
    // [HttpPost("/vendors/{vendorId}/orders/{orderId}/delete")]
    // public ActionResult DeleteOrder(int orderId)
    // {
    //   Order.CancelOrder(orderId);
    //   return View();
    // }
    // *** END WIP ***
  }
}