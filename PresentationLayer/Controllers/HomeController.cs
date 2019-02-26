using PresentationLayer.Models;
using Repository.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {

        private P1TiendaVirtualDBEntities db = new P1TiendaVirtualDBEntities();

        public ActionResult Index(CarritoCompra cc)
        {
            return View("Productos", db.Productos.ToList());
        }

        public ActionResult Productos(CarritoCompra cc)
        {
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "P1 Tienda Online.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Página de Contacto.";

            return View();
        }
    }
}