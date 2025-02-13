using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackendSegurosABC;

[Route("api/[controller]")]
[ApiController]
public class AseguradosController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AseguradosController(ApplicationDbContext context)
    {
        _context = context;
    }

    // POST: api/asegurados/Crear_Asegurado: crea un asegurado
    [HttpPost("Crear_Asegurado")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<SegurosAbc>> PostAsegurado(SegurosAbc asegurado)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState); 
        }

        try
        {
            var existingAsegurado = await _context.SegurosAbc
                .FirstOrDefaultAsync(a => a.Identificacion == asegurado.Identificacion);

            if (existingAsegurado != null)
            {
                return Conflict("El asegurado con esta identificacion ya existe.");
            }

            _context.SegurosAbc.Add(asegurado);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAsegurado), new { Identificacion = asegurado.Identificacion }, asegurado);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Hubo un problema al procesar la solicitud.");
        }
    }



    // GET: api/asegurados: muestra la lista de asegurados
    [HttpGet("Listar_Asegurados")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<SegurosAbc>>> GetAsegurados([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var asegurados = await _context.SegurosAbc
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return Ok(new { total = _context.SegurosAbc.Count(), data = asegurados });
    }

    // PUT: api/asegurados: actualiza asegurado
    [HttpPut("Actualizar_Asegurado/{Identificacion}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> PutAsegurado(int Identificacion, SegurosAbc asegurado)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState); 
        }

        var existingAsegurado = await _context.SegurosAbc
            .FirstOrDefaultAsync(a => a.Identificacion == asegurado.Identificacion);

        if (existingAsegurado == null)
        {
            return NotFound("El asegurado no existe."); 
        }

        if (Identificacion != asegurado.Identificacion)
        {
            return BadRequest("La identificación proporcionada no coincide con el del asegurado."); 
        }

        try
        {
            existingAsegurado.PrimerNombre = asegurado.PrimerNombre;
            existingAsegurado.SegundoNombre = asegurado.SegundoNombre;
            existingAsegurado.PrimerApellido = asegurado.PrimerApellido;
            existingAsegurado.SegundoApellido = asegurado.SegundoApellido;
            existingAsegurado.Telefono = asegurado.Telefono;
            existingAsegurado.CorreoElectronico = asegurado.CorreoElectronico;
            existingAsegurado.FechaNacimiento = asegurado.FechaNacimiento;
            existingAsegurado.ValorEstimado = asegurado.ValorEstimado;
            existingAsegurado.Observaciones = asegurado.Observaciones;

            await _context.SaveChangesAsync();

            return Ok(asegurado);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Hubo un problema al procesar la solicitud. Detalles del error: {ex.Message}");
        }
    }



    // DELETE: api/asegurados/Eliminar_Asegurados/{id}: eliminar asegurados
    [HttpDelete("Eliminar_Asegurados/{Identificacion}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteAsegurado(int Identificacion)
    {

        var asegurado = await _context.SegurosAbc
            .FirstOrDefaultAsync(a => a.Identificacion == Identificacion);
        if (asegurado == null)
        {
            return NotFound(new { message = "El asegurado no fue encontrado." });
        }

        try
        {
            _context.SegurosAbc.Remove(asegurado);
            await _context.SaveChangesAsync();

            return Ok(new { message = "El asegurado fue eliminado exitosamente." });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                message = "Ocurrió un error al procesar la solicitud.",
                detail = ex.Message
            });
        }
    }

    // GET: api/asegurados: buscar asegurado por identificacion
    [HttpGet("Filtrar_Asegurados/{Identificacion}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<SegurosAbc>> GetAsegurado(int Identificacion)
    {
        try
        {
            var asegurado = await _context.SegurosAbc.FirstOrDefaultAsync(a => a.Identificacion == Identificacion);

            if (asegurado == null)
            {
                return NotFound(new { message = "El asegurado no fue encontrado." });
            }

            return Ok(asegurado);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                message = "Ocurrió un error al procesar la solicitud.",
                detail = ex.Message
            });
        }
    }


}
