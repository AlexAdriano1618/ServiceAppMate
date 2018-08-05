using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicioAppU.ModelosNuevos;

namespace ServicioAppU.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Codigoes")]
    public class CodigoesController : Controller
    {
        private readonly Ejemplo94Context _context;

        public CodigoesController(Ejemplo94Context context)
        {
            _context = context;
        }

        // GET: api/Codigoes
        [HttpGet]
        public async Task<IEnumerable<Codigo>> GetCodigoAsync()
        {
            var lista = await _context.Codigo.ToListAsync();
            return lista;
        }

        // GET: api/Codigoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCodigo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var codigo = await _context.Codigo.SingleOrDefaultAsync(m => m.IdCodigo == id);

            if (codigo == null)
            {
                return NotFound();
            }

            return Ok(codigo);
        }

        // PUT: api/Codigoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCodigo([FromRoute] int id, [FromBody] Codigo codigo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != codigo.IdCodigo)
            {
                return BadRequest();
            }

            _context.Entry(codigo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CodigoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Codigoes
        [HttpPost]
        public async Task<IActionResult> PostCodigo([FromBody] Codigo codigo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Codigo.Add(codigo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCodigo", new { id = codigo.IdCodigo }, codigo);
        }

        // DELETE: api/Codigoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCodigo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var codigo = await _context.Codigo.SingleOrDefaultAsync(m => m.IdCodigo == id);
            if (codigo == null)
            {
                return NotFound();
            }

            _context.Codigo.Remove(codigo);
            await _context.SaveChangesAsync();

            return Ok(codigo);
        }

        private bool CodigoExists(int id)
        {
            return _context.Codigo.Any(e => e.IdCodigo == id);
        }
    }
}