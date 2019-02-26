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

        public static void Add(Producto nuevoProd)
        {
            P1TiendaVirtualDBEntities Te = new P1TiendaVirtualDBEntities();
            Te.Productos.Add(nuevoProd);
            Te.SaveChanges();
        }

        public IEnumerable GetProductosList()
        {
            P1TiendaVirtualDBEntities Te = new P1TiendaVirtualDBEntities();
            return Te.Productos;
        }
    }
}
