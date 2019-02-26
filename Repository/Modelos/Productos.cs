using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Modelos
{
    public class Productos
    {
        P1TiendaVirtualDBEntities Te = new P1TiendaVirtualDBEntities();

        public void Add(string nombre, string descripcion,
            float precio, int cantidad, string fotoUri)
        {
            Producto nuevoProd = new Producto();
            nuevoProd.nombre = nombre;
            nuevoProd.descripcion = descripcion;
            nuevoProd.precio = precio;
            nuevoProd.cantidad = cantidad;
            nuevoProd.fotoUri = fotoUri;
            Te.Productos.Add(nuevoProd);
        }

        public IEnumerable GetProductosList()
        {
            return Te.Productos;
        }
    }
}
