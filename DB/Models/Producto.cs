using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DB.Models
{
    public class Producto : IValidatableObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        //Clave Foranea
        [ForeignKey("CategoriaId")]
        public int CategoriaId { get; set; }
        public virtual Categoria? Categoria { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Descripcion.Length < 2 || Descripcion.Length > 10)
            {
                yield return new ValidationResult("la descripcion debe estar entre 2 y 10", new[] { Descripcion });
            }
        }
    }
}
