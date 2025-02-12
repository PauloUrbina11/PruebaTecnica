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

    // GET: api/asegurados
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SegurosAbc>>> GetAsegurados()
    {
        return await _context.SegurosAbc.ToListAsync();
    }

    // GET: api/asegurados/5
    [HttpGet("{id}")]
    public async Task<ActionResult<SegurosAbc>> GetAsegurado(int id)
    {
        var asegurado = await _context.SegurosAbc.FindAsync(id);

        if (asegurado == null)
        {
            return NotFound();
        }

        return asegurado;
    }

    // POST: api/asegurados
    [HttpPost]
    public async Task<ActionResult<SegurosAbc>> PostAsegurado(SegurosAbc asegurado)
    {
        _context.SegurosAbc.Add(asegurado);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAsegurado), new { id = asegurado.Id }, asegurado);
    }

    // PUT: api/asegurados/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsegurado(int id, SegurosAbc asegurado)
    {
        if (id != asegurado.Id)
        {
            return BadRequest();
        }

        _context.Entry(asegurado).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/asegurados/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsegurado(int id)
    {
        var asegurado = await _context.SegurosAbc.FindAsync(id);
        if (asegurado == null)
        {
            return NotFound();
        }

        _context.SegurosAbc.Remove(asegurado);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
