using DeliveryCart.App_Start;
using DeliveryCart.Models;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections;
using System.Web.Mvc;

public class HomeController : Controller
{
    public ActionResult Index()
    {
        return RedirectToAction("Submit");
    }

    public ActionResult About()
    {
        ViewBag.Message = "Your application description page.";

        return View();
    }

    public ActionResult Contact()
    {
        ViewBag.Message = "Your contact page.";

        return View();
    }

    public ActionResult Submit()
    {
        var namespaceManager = connector.CreateNamespaceManager();

        var queue = namespaceManager.GetQueue(connector.QueName);

        ViewBag.MessageCount = queue.MessageCount;

        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Submit(Deliverymodel order)
    {
        if (ModelState.IsValid)
        {
            var message = new BrokeredMessage(order);
            connector.OrdersQueueClient.Send(message);
            return RedirectToAction("Submit");

        }
        else
        {
            return View(order);
        }
    }
}

   





