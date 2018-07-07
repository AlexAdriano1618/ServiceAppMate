using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServicioAppU.ModelosNuevos;

namespace ServicioAppU.Controllers.Mvc
{
    public class PreguntasController : Controller
    {
        private readonly Ejemplo94Context _context;

        public PreguntasController(Ejemplo94Context context)
        {
            _context = context;
        }

        // GET: Preguntas
        public async Task<IActionResult> Index()
        {
            var ejemplo94Context = _context.Preguntas.Include(p => p.IdCodigoNavigation);
            return View(await ejemplo94Context.ToListAsync());
        }

        // GET: Preguntas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preguntas = await _context.Preguntas
                .Include(p => p.IdCodigoNavigation)
                .SingleOrDefaultAsync(m => m.IdPreguntas == id);
            if (preguntas == null)
            {
                return NotFound();
            }

            return View(preguntas);
        }

        // GET: Preguntas/Create
        public IActionResult Create()
        {
            ViewData["IdCodigo"] = new SelectList(_context.Codigo, "IdCodigo", "Descripcion");
            return View();
        }

        // POST: Preguntas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPreguntas,IdCodigo,Descripcion")] Preguntas preguntas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(preguntas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCodigo"] = new SelectList(_context.Codigo, "IdCodigo", "Descripcion", preguntas.IdCodigo);
            return View(preguntas);
        }

        // GET: Preguntas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preguntas = await _context.Preguntas.SingleOrDefaultAsync(m => m.IdPreguntas == id);
            if (preguntas == null)
            {
                return NotFound();
            }
            ViewData["IdCodigo"] = new SelectList(_context.Codigo, "IdCodigo", "Descripcion", preguntas.IdCodigo);
            return View(preguntas);
        }

        // POST: Preguntas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPreguntas,IdCodigo,Descripcion")] Preguntas preguntas)
        {
            if (id != preguntas.IdPreguntas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(preguntas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PreguntasExists(preguntas.IdPreguntas))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCodigo"] = new SelectList(_context.Codigo, "IdCodigo", "Descripcion", preguntas.IdCodigo);
            return View(preguntas);
        }

        // GET: Preguntas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preguntas = await _context.Preguntas
                .Include(p => p.IdCodigoNavigation)
                .SingleOrDefaultAsync(m => m.IdPreguntas == id);
            if (preguntas == null)
            {
                return NotFound();
            }

            return View(preguntas);
        }

        // POST: Preguntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var preguntas = await _context.Preguntas.SingleOrDefaultAsync(m => m.IdPreguntas == id);
            _context.Preguntas.Remove(preguntas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PreguntasExists(int id)
        {
            return _context.Preguntas.Any(e => e.IdPreguntas == id);
        }
    }
}
