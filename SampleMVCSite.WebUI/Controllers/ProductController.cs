using SampleMVCSite.Contracts.Repositories;
using SampleMVCSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMVCSite.WebUI.Controllers
{
    public class ProductController : Controller
    {
        IRepositoryBase<Product> products;
        // GET: Product
        public ProductController( IRepositoryBase<Product> products )
        {
            this.products = products;
        }

        public ActionResult Index()
        {
            //return RedirectToAction("ProductsList");
            return View();
        }

        public ActionResult ProductsList()
        {
            var model = products.GetAll();
            return View(model);
        }

        public ActionResult ProductDetail( int id )
        {
            var model = products.GetById(id);
            return View(model);
        }


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


    }
}
