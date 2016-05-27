using SampleMVCSite.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleMVCSite.Models;

namespace SampleMVCSite.WebUI.Controllers
{
    public class OrderController : Controller
    {

        IRepositoryBase<Order> orders;
        // GET: Order
        public OrderController(IRepositoryBase<Order> orders)
        {
            this.orders = orders;
        }

        // GET: Order
        public ActionResult Index()
        {
            return RedirectToAction("OrderList");
        }

        public ActionResult OrderList()
        {
            var model = orders.GetAll();
            return View(model);
        }

        public ActionResult OrderDetail(int id)
        {
            var model = orders.GetById(id);
            return View(model);
        }

         public ActionResult CreateOrder()
        {
            var model = new Order();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateOrder(Order order)
        {
            orders.Insert(order);
            orders.Commit();
            return RedirectToAction("OrderList");
        }

        public ActionResult DeleteOrder(int id)
        {
            Order Order = orders.GetById(id);
            return View(Order);
        }

        [HttpPost, ActionName("DeleteOrder")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOrderConfirm(int id)
        {
            orders.Delete(orders.GetById(id));
            //Orders.Delete(Order);
            orders.Commit();
            return RedirectToAction("OrderList");
        }

        public ActionResult EditOrder(int id)
        {
            Order Order = orders.GetById(id);
            return View(Order);
        }
        [HttpPost]
        public ActionResult EditOrder(Order Order)
        {
            orders.Update(Order);
            orders.Commit();

            return RedirectToAction("OrderList");
        }





    }
}
