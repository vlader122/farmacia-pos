using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        [JsonIgnore]
        public int VentaId { get; set; }
        [JsonIgnore]
        public virtual Producto ?Producto { get; set; }
        [JsonIgnore]
        public virtual Venta ?Venta { get; set; }
    }
}
