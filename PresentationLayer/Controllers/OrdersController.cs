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
        private P1TiendaVirtualDBEntities db = new P1TiendaVirtualDBEntities();

        // GET: Orders
        public ActionResult Index()
        {
            return RedirectToAction("Cart");
        }

        // GET: Orders/cart
        public ActionResult Cart(CarritoCompra cc)
        {
            return View(cc);
        }

        // GET: Orders/QuitarProducto/3
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

        // GET: Orders/Checkout
        public ActionResult Checkout(CarritoCompra cc)
        {
            return View(cc);
        }

        // POST: Orders/Checkout
        public ActionResult FinalizarCheckout(string nombreCliente, string emailCliente,
            string telefonoCliente, string direccionEnvio, CarritoCompra cc)
        {
            bool productosDisponibles = true;
            //Estan disponibles los productos deseados?
            foreach (Producto item in cc)
            {
                Producto prod = db.Productos.Find(item.Id);
                if (prod.cantidad <= item.cantidad)
                {
                    productosDisponibles = false;
                }
            }
            if (productosDisponibles)
            {
                //Reducir cantidad disponible de producto en base de datos.
                foreach (Producto item in cc)
                {
                    Producto prod = db.Productos.Find(item.Id);
                    db.Productos.Find(item.Id).cantidad = prod.cantidad - item.cantidad;
                    db.SaveChanges();
                }
                string detalle = "";
                decimal subtotal = 0;
                decimal iva = 0;
                decimal total = 0;
                decimal envio = (decimal)5.99;
                foreach (var item in cc)
                {
                    subtotal += (decimal) item.precio;
                    detalle = detalle + " (x" + item.cantidad + ") " + item.nombre + "[" + item.Id + "]" + " @ " + item.precio;
                }
                iva = subtotal * (decimal)0.21;
                total = subtotal + iva + envio;
                Pedido nuevoPedido = new Pedido();
                nuevoPedido.nombre_cliente = nombreCliente;
                nuevoPedido.email_cliente = emailCliente;
                nuevoPedido.telefono_cliente = telefonoCliente;
                nuevoPedido.direccion_cliente = direccionEnvio;
                nuevoPedido.detalle = detalle;
                nuevoPedido.subtotal = (float) subtotal;
                nuevoPedido.iva = (float) iva;
                nuevoPedido.envio = (float) envio;
                nuevoPedido.total = (float) total;
                db.Pedidos.Add(nuevoPedido);
                db.SaveChanges();
                cc.LimpiarCarrito(ControllerContext);
                return View(nuevoPedido);
            }
            return View("CheckoutError");
        }

    }
}