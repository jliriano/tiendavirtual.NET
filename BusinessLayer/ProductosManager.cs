using Repository.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    class ProductosManager
    {

        public void addProducto(string nombre, string descripcion,
            float precio, int cantidad, string fotoUri)
        {
            Productos ProductoManager = new Productos();
            ProductoManager.Add(nombre, descripcion, precio, cantidad, fotoUri);
        }
        

    }
}
