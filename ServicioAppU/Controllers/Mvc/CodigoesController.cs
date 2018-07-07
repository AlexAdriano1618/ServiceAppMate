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
    public class CodigoesController : Controller
    {
        private readonly Ejemplo94Context _context;

        public CodigoesController(Ejemplo94Context context)
        {
            _context = context;
        }

        // GET: Codigoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Codigo.ToListAsync());
        }

        // GET: Codigoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codigo = await _context.Codigo
                .SingleOrDefaultAsync(m => m.IdCodigo == id);
            if (codigo == null)
            {
                return NotFound();
            }

            return View(codigo);
        }

        // GET: Codigoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Codigoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCodigo,Identificacion,Descripcion")] Codigo codigo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(codigo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(codigo);
        }

        // GET: Codigoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codigo = await _context.Codigo.SingleOrDefaultAsync(m => m.IdCodigo == id);
            if (codigo == null)
            {
                return NotFound();
            }
            return View(codigo);
        }

        // POST: Codigoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCodigo,Identificacion,Descripcion")] Codigo codigo)
        {
            if (id != codigo.IdCodigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(codigo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CodigoExists(codigo.IdCodigo))
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
            return View(codigo);
        }

        // GET: Codigoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codigo = await _context.Codigo
                .SingleOrDefaultAsync(m => m.IdCodigo == id);
            if (codigo == null)
            {
                return NotFound();
            }

            return View(codigo);
        }

        // POST: Codigoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var codigo = await _context.Codigo.SingleOrDefaultAsync(m => m.IdCodigo == id);
            _context.Codigo.Remove(codigo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CodigoExists(int id)
        {
            return _context.Codigo.Any(e => e.IdCodigo == id);
        }
    }
}
