using PresentationLayer.Models;
using Repository.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class ProductoController : Controller
    {

        private P1TiendaVirtualDBEntities db = new P1TiendaVirtualDBEntities();

        // GET: Producto/5
        public ActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Producto
        public ActionResult AddCarrito(int productoId, int productoCant, CarritoCompra cc)
        {
            Producto np = new Producto();
            np = db.Productos.Find(productoId);
            np.cantidad = productoCant;

            //Buscar redundancias
            Producto ep = cc.Find(x => x.Id == productoId);
            if (ep != null)
            {
                np.cantidad += ep.cantidad;
                int index = cc.IndexOf(ep);
                cc[index] = np;
            }
            else
            {
                cc.Add(np);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}