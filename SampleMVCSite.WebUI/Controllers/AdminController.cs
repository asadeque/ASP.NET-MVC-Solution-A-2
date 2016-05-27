using SampleMVCSite.Contracts.Repositories;
using SampleMVCSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMVCSite.WebUI.Controllers
{
    public class AdminController : Controller
    {
        IRepositoryBase<Customer> customers;
        IRepositoryBase<Product> products;
        //IRepositoryBase<Order> orders;

        public AdminController(IRepositoryBase<Customer> customers, IRepositoryBase<Product> products) //, IRepositoryBase<Order> orders
        {
            this.customers = customers;
            this.products = products;
            //this.orders = orders;
        }//end Constructor

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductsList()
        {
            var model = products.GetAll();
            return View(model);
        }

        public ActionResult CustomerList()
        {
            var model = customers.GetAll();
            return View(model);
        }

        //public ActionResult OrderList()
        //{
        //    var model = orders.GetAll();
        //    return View(model);
        //}


        //create product method
        public ActionResult CreateProduct()
        {
            var model = new Product();
            return View(model);
        }
        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            products.Insert(product);
            products.Commit();
            return RedirectToAction("ProductsList");
        }
        //create customer method
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


        //edit product method
        public ActionResult EditProduct(int id)
        {
            Product product = products.GetById(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            products.Update(product);
            products.Commit();

            return RedirectToAction("ProductsList");
        }
        //edit customer method
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
        //delete product method
        public ActionResult DeleteProduct(int id)
        {
            Product product = products.GetById(id);
            return View(product);
        }

        [HttpPost, ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProductConfirm(int id)
        {
            products.Delete(products.GetById(id));
            //products.Delete(product);
            products.Commit();
            return RedirectToAction("ProductsList");
        }
        //delete customer method
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

        //product detail method
        public ActionResult ProductDetail(int id)
        {
            var model = products.GetById(id);
            return View(model);
        }

        //customer detail method
        public ActionResult CustomerDetail(int id)
        {
            var model = customers.GetById(id);
            return View(model);
        }

    }
}
