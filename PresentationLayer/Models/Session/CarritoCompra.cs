using Repository.Modelos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Models
{
    public class CarritoCompra : List<Producto>
    {
        public void LimpiarCarrito(ControllerContext controllerContext)
        {
            var cc = new CarritoCompra();
            controllerContext.HttpContext.Session["carrito"] = cc;
        }
    }
}