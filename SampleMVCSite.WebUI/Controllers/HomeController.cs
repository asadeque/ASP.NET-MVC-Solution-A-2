using System.Web.Mvc;
using SampleMVCSite.Contracts.Repositories;
using SampleMVCSite.Contracts.Data;
using SampleMVCSite.Models;


namespace SampleMVCSite.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepositoryBase<Customer> customers;
        IRepositoryBase<Product> products;

        public HomeController(IRepositoryBase<Customer> customers, IRepositoryBase<Product>products) {
            this.customers = customers;
            this.products = products;
        }
        public ActionResult Index()
        {
            var productList = products.GetAll();

            return View(productList);
            //return View();
        }

        public ActionResult Details(int id)
        {
            var product = products.GetById(id);
            return View(product);
        }

        public ActionResult About()
        {
            ViewBag.Message = "KAS believes in quality.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "We are committed for quick service.";

            return View();
        }
    }
}
