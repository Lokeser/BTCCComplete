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
    public class BancasController : Controller
    {
        private readonly BancaTCCContext _context;

        public BancasController(BancaTCCContext context)
        {
            _context = context;
        }

        // GET: Bancas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bancas.ToListAsync());
        }

        // GET: Bancas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banca = await _context.Bancas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (banca == null)
            {
                return NotFound();
            }

            return View(banca);
        }

        // GET: Bancas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bancas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data,HoraInicio,HoraFim,Resultado,Observacoes,TrabalhoId")] Banca banca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(banca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(banca);
        }

        // GET: Bancas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banca = await _context.Bancas.FindAsync(id);
            if (banca == null)
            {
                return NotFound();
            }
            return View(banca);
        }

        // POST: Bancas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Data,HoraInicio,HoraFim,Resultado,Observacoes,TrabalhoId")] Banca banca)
        {
            if (id != banca.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(banca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BancaExists(banca.Id))
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
            return View(banca);
        }

        // GET: Bancas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banca = await _context.Bancas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (banca == null)
            {
                return NotFound();
            }

            return View(banca);
        }

        // POST: Bancas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var banca = await _context.Bancas.FindAsync(id);
            if (banca != null)
            {
                _context.Bancas.Remove(banca);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BancaExists(int id)
        {
            return _context.Bancas.Any(e => e.Id == id);
        }
    }
}
