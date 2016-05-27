using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleMVCSite.Models;
using SampleMVCSite.Contracts.Repositories;

namespace SampleMVCSite.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        IRepositoryBase<Customer> customers;
        // GET: Order
        public CustomerController(IRepositoryBase<Customer> customers)
        {
            this.customers = customers;
        }

        // GET: Order
        public ActionResult Index()
        {
            //return RedirectToAction("CustomerList");
            return View();
        }

        public ActionResult CustomerList()
        {
            var model = customers.GetAll();
            return View(model);
        }

        public ActionResult CustomerDetail(int id)
        {
            var model = customers.GetById(id);
            return View(model);
        }

         public ActionResult CreateCustomer()
        {
            var model = new Customer();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateCustomer(Customer customer)
        {
            customers.Insert(customer);
            customers.Commit();
            return RedirectToAction("CustomerList");
        }

        public ActionResult DeleteCustomer(int id)
        {
            Customer customer = customers.GetById(id);
            return View(customer);
        }

        [HttpPost, ActionName("DeleteCustomer")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCustomerConfirm(int id)
        {
            customers.Delete(customers.GetById(id));
            customers.Commit();
            return RedirectToAction("CustomerList");
        }

        public ActionResult EditCustomer(int id)
        {
            Customer customer = customers.GetById(id);
            return View(customer);
        }
        [HttpPost]
        public ActionResult EditCustomer(Customer customer)
        {
            customers.Update(customer);
            customers.Commit();

            return RedirectToAction("CustomerList");
        }
    }
}
