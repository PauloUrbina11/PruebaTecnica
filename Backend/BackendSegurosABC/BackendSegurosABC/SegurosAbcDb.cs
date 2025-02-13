using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendSegurosABC
{
    // Definición de la clase de SegurosAbc
    [Table("asegurados")]
    public class SegurosAbc
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("identificacion")]
        public int Identificacion { get; set; }

        [Column("primer_nombre")]
        public string PrimerNombre { get; set; } = string.Empty;

        [Column("segundo_nombre")]
        public string? SegundoNombre { get; set; }

        [Column("primer_apellido")]
        public string PrimerApellido { get; set; } = string.Empty;

        [Column("segundo_apellido")]
        public string SegundoApellido { get; set; } = string.Empty;

        [Column("telefono")]
        public string Telefono { get; set; } = string.Empty;

        [Column("correo_electronico")]
        public string CorreoElectronico { get; set; } = string.Empty;

        [Column("fecha_nacimiento")]
        public DateOnly FechaNacimiento { get; set; }

        [Column("valor_estimado")]
        public decimal ValorEstimado { get; set; }

        [Column("observaciones")]
        public string? Observaciones { get; set; }
    }

}

