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
    [Route("api/Preguntas")]
    public class PreguntasController : Controller
    {
        private readonly Ejemplo94Context _context;

        public PreguntasController(Ejemplo94Context context)
        {
            _context = context;
        }

        // GET: api/Preguntas
        [HttpGet]
        public IEnumerable<Preguntas> GetPreguntas()
        {
            return _context.Preguntas;
        }

        // GET: api/Preguntas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPreguntas([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var preguntas = await _context.Preguntas.SingleOrDefaultAsync(m => m.IdPreguntas == id);

            if (preguntas == null)
            {
                return NotFound();
            }

            return Ok(preguntas);
        }

        // PUT: api/Preguntas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreguntas([FromRoute] int id, [FromBody] Preguntas preguntas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != preguntas.IdPreguntas)
            {
                return BadRequest();
            }

            _context.Entry(preguntas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreguntasExists(id))
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

        // POST: api/Preguntas
        [HttpPost]
        public async Task<IActionResult> PostPreguntas([FromBody] Preguntas preguntas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Preguntas.Add(preguntas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreguntas", new { id = preguntas.IdPreguntas }, preguntas);
        }

        // DELETE: api/Preguntas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreguntas([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var preguntas = await _context.Preguntas.SingleOrDefaultAsync(m => m.IdPreguntas == id);
            if (preguntas == null)
            {
                return NotFound();
            }

            _context.Preguntas.Remove(preguntas);
            await _context.SaveChangesAsync();

            return Ok(preguntas);
        }

        private bool PreguntasExists(int id)
        {
            return _context.Preguntas.Any(e => e.IdPreguntas == id);
        }
    }
}