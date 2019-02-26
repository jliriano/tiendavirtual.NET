using Repository.Modelos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ProductosManager
    {
        Productos ProductoManager = new Productos();

        public void addProducto(string nombre, string descripcion,
            float precio, int cantidad, string fotoUri)
        {
            ProductoManager.Add(nombre, descripcion, precio, cantidad, fotoUri);
        }

        public IEnumerable getProductos()
        {
            return ProductoManager.GetProductosList();
        }
        

    }
}
