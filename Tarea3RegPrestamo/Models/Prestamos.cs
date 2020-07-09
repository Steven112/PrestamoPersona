using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tarea3RegPrestamo.Models
{
    public class Prestamos
    {
        [Key]
        [Required(ErrorMessage = "El campo ID no puede estar vacío.")]
        [Range(0, 999999, ErrorMessage = "Prestamo Id no puede ser menor que cero o mayor a 999999")]
        public int PrestamoId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir una fecha diferente")]
        public DateTime FechaPrestamo { get; set; }

        [Required(ErrorMessage = "Es obligatorio seleccionar una persona")]
        public int PersonaId { get; set; }

        [Required(ErrorMessage = "Es obligatorio llenar este campo")]
        [MinLength(4, ErrorMessage = "El campo debe tener por lo menos 4 caracteres")]
        public string Concepto { get; set; }

        [Range(minimum: 1, maximum: 999999999, ErrorMessage = "Agregue un monto mayor a 0")]
        [Required(ErrorMessage = "El monto no puede estar vacío")]
        public decimal Monto { get; set; }
        public decimal Balances { get; set; }

        public Prestamos()
        {
            PrestamoId =0;
            FechaPrestamo = DateTime.Now;
            PersonaId = 0;
            Concepto = string.Empty;
            Monto = 0;
            Balances = 15;
        }

        public Prestamos(int prestamoId, DateTime fechaPrestamo, int personaId, string concepto, decimal monto, decimal balances)
        {
            PrestamoId = prestamoId;
            FechaPrestamo = fechaPrestamo;
            PersonaId = personaId;
            Concepto = concepto;
            Monto = monto;
            Balances = balances;
        }
    }
}
