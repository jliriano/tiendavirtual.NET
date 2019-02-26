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

        public void addProducto(Producto producto)
        {
            Repository.Modelos.Productos.Add(producto);
        }

        public IEnumerable getProductos()
        {
            return ProductoManager.GetProductosList();
        }
        

    }
}
