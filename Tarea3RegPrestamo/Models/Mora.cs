using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tarea3RegPrestamo.Models
{
    public class Mora
    {
        [Key]
        [Required(ErrorMessage = "El campo ID no puede estar vacío")]
        [Range(0, 999999, ErrorMessage = "El campo MoraId no puede ser menor que cero o mayor a 999999")]
        public int MoraId { get; set; }

        [Required(ErrorMessage = "Es obligatorio llenar el campo")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Es obligatorio llenar el campo")]
        [Range(0, 99999999, ErrorMessage = "Cantidad Invalida")]
        public Decimal Total { get; set; }

        [ForeignKey("MoraId")]
        public virtual List<MoraDetalle> moradetalles { get; set; } = new List<MoraDetalle>();

        public Mora()
        {
            MoraId = 0;
            Fecha = DateTime.Now;
            Total = 0;
            moradetalles=new List<MoraDetalle>();
        }
    }

    public class MoraDetalle
    {
        [Key]
        [Required(ErrorMessage = "El campo ID no puede estar vacío")]
        [Range(0, 999999, ErrorMessage = "El campo MoraId no puede ser menor que cero o mayor a 999999")]
        public int DetalleId { get; set; }

        [Required(ErrorMessage = "El campo ID no puede estar vacío")]
        [Range(0, 999999, ErrorMessage = "El campo MoraId no puede ser menor que cero o mayor a 999999")]
        public int MoraId { get; set; }

        [Required(ErrorMessage = "El campo ID no puede estar vacío")]
        [Range(0, 999999, ErrorMessage = "El campo MoraId no puede ser menor que cero o mayor a 999999")]
        public int PrestamoId { get; set; }
        [ForeignKey("PrestamosId")]
        public Prestamos prestamos { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        public Decimal Valor { get; set; }

        public MoraDetalle()
        {
            DetalleId =0;
            MoraId =0;
            PrestamoId = 0;
            this.prestamos = prestamos;
            Valor = 0;
        }

        public MoraDetalle(int detalleId, int moraId, int prestamoId, decimal valor)
        {
            DetalleId = detalleId;
            MoraId = moraId;
            PrestamoId = prestamoId;
            Valor = valor;
        }
    }
}
