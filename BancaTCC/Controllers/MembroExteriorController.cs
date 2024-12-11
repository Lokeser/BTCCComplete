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
    public class MembroExteriorController : Controller
    {
        private readonly BancaTCCContext _context;

        public MembroExteriorController(BancaTCCContext context)
        {
            _context = context;
        }

        // GET: MembroExterior
        public async Task<IActionResult> Index()
        {
            return View(await _context.MembrosExternos.ToListAsync());
        }

        // GET: MembroExterior/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membroExterior = await _context.MembrosExternos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (membroExterior == null)
            {
                return NotFound();
            }

            return View(membroExterior);
        }

        // GET: MembroExterior/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MembroExterior/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Telefone,Email")] MembroExterior membroExterior)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membroExterior);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(membroExterior);
        }

        // GET: MembroExterior/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membroExterior = await _context.MembrosExternos.FindAsync(id);
            if (membroExterior == null)
            {
                return NotFound();
            }
            return View(membroExterior);
        }

        // POST: MembroExterior/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Telefone,Email")] MembroExterior membroExterior)
        {
            if (id != membroExterior.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membroExterior);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembroExteriorExists(membroExterior.Id))
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
            return View(membroExterior);
        }

        // GET: MembroExterior/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membroExterior = await _context.MembrosExternos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (membroExterior == null)
            {
                return NotFound();
            }

            return View(membroExterior);
        }

        // POST: MembroExterior/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var membroExterior = await _context.MembrosExternos.FindAsync(id);
            if (membroExterior != null)
            {
                _context.MembrosExternos.Remove(membroExterior);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembroExteriorExists(int id)
        {
            return _context.MembrosExternos.Any(e => e.Id == id);
        }
    }
}
