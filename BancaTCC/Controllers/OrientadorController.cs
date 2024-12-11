using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BancaTCC.Data;
using BancaTCC.Models;

namespace BancaTCC.Controllers
{
    public class OrientadorController : Controller
    {
        private readonly BancaTCCContext _context;

        public OrientadorController(BancaTCCContext context)
        {
            _context = context;
        }

        // GET: Orientador
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrientadoresIndicados.ToListAsync());
        }

        // GET: Orientador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orientador = await _context.OrientadoresIndicados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orientador == null)
            {
                return NotFound();
            }

            return View(orientador);
        }

        // GET: Orientador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orientador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrdemPreferencia,Status")] Orientador orientador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orientador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orientador);
        }

        // GET: Orientador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orientador = await _context.OrientadoresIndicados.FindAsync(id);
            if (orientador == null)
            {
                return NotFound();
            }
            return View(orientador);
        }

        // POST: Orientador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrdemPreferencia,Status")] Orientador orientador)
        {
            if (id != orientador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orientador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrientadorExists(orientador.Id))
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
            return View(orientador);
        }

        // GET: Orientador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orientador = await _context.OrientadoresIndicados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orientador == null)
            {
                return NotFound();
            }

            return View(orientador);
        }

        // POST: Orientador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orientador = await _context.OrientadoresIndicados.FindAsync(id);
            if (orientador != null)
            {
                _context.OrientadoresIndicados.Remove(orientador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrientadorExists(int id)
        {
            return _context.OrientadoresIndicados.Any(e => e.Id == id);
        }
    }
}
