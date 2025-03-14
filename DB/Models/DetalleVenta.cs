using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class DetalleVenta
    {
        public int DetalleVentaId { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        //relaciones
        public int ProductoId { get; set; }
        public int VentaId { get; set; }
        public virtual Producto ?Producto { get; set; }
        public virtual Venta ?Venta { get; set; }
    }
}
