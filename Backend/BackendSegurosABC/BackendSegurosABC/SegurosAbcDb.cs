using Microsoft.EntityFrameworkCore;

namespace BackendSegurosABC
{
    public class SegurosAbc
    {
        public int Id { get; set; }
        public decimal Identificacion { get; set; }
        public string PrimerNombre { get; set; } = string.Empty;
        public string? SegundoNombre { get; set; }
        public string PrimerApellido { get; set; } = string.Empty;
        public string SegundoApellido { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateOnly FechaNacimiento { get; set; }
        public decimal ValorEstimado { get; set; }
        public string? Observaciones { get; set; }
    }

}

