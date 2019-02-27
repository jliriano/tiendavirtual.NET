using PresentationLayer.Models;
using Repository.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index()
        {
            return RedirectToAction("Cart");
        }

        //GET: Orders/cart
        public ActionResult Cart(CarritoCompra cc)
        {
            return View(cc);
        }

        //GET: Orders/QuitarProducto/3
        public ActionResult QuitarProducto(int? id, CarritoCompra cc)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Producto p = cc.Find(x => x.Id == id);
            cc.Remove(p);
            return RedirectToAction("Cart");
        }

        //POST: Orders/Checkout
        public ActionResult Checkout(CarritoCompra cc)
        {
            return View(cc);
        }

    }
}