using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DB.Models
{
    public class Venta
    {
        public int VentaId { get; set; }
        public int Factura { get; set; }
        public DateOnly Fecha { get; set; }
        public decimal Total { get; set; }

        //relaciones
        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        [JsonIgnore]
        public virtual Cliente? Cliente { get; set; }

        public virtual ICollection<DetalleVenta> DetalleVentas { get; set; }


    }
}
