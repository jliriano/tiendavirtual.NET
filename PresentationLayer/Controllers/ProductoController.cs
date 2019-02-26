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
    }
}