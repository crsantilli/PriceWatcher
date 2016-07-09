using PriceWatcher.DAL.DTOs;
using PriceWatcher.DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PriceWatcher.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult GetValues()
        {
            List<Country> countries = new List<Country>();

            countries.Add(new Country() { name = "Tokyo", data = new List<decimal> { 7.0m, 6.9m, 9.5m, 14.5m, 18.2m, 21.5m, 25.2m, 26.5m, 23.3m, 18.3m, 13.9m, 9.6m } });
            countries.Add(new Country() { name = "New York", data = new List<decimal> { -0.2m, 0.8m, 5.7m, 11.3m, 17.0m, 22.0m, 24.8m, 24.1m, 20.1m, 14.1m, 8.6m, 2.5m } });
            countries.Add(new Country() { name = "Berlin", data = new List<decimal> { -0.9m, 0.6m, 3.5m, 8.4m, 13.5m, 17.0m, 18.6m, 17.9m, 14.3m, 9.0m, 3.9m, 1.0m } });
            countries.Add(new Country() { name = "London", data = new List<decimal> { 3.9m, 4.2m, 5.7m, 8.5m, 11.9m, 15.2m, 17.0m, 16.6m, 14.2m, 10.3m, 6.6m, 4.8m} });

            PriceService.Instance.UpdatePrices();           

            List<ProductDTO> products = ProductService.Instance.GetAll();


            return Json(new { countries = countries }, JsonRequestBehavior.AllowGet);
        }

        public class Country
        {
            public string name { get; set; }
            public List<decimal> data { get; set; }
        }
    }
}