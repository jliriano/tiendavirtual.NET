using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PresentationLayer.Models;

namespace PresentationLayer.Models.Binders
{
    public class CarritoCompraModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var cc = controllerContext.HttpContext.Session["carrito"];

            if (cc == null)
            {
                cc = new CarritoCompra();
                controllerContext.HttpContext.Session["carrito"] = cc;
            }

            return (CarritoCompra)cc;
        }
    }
}