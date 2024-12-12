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
    public class TrabalhoController : Controller
    {
        private readonly BancaTCCContext _context;

        public TrabalhoController(BancaTCCContext context)
        {
            _context = context;
        }

        // GET: Trabalho
        public async Task<IActionResult> Index()
        {
            var bancaTCCContext = _context.Trabalhos.Include(t => t.Autor).Include(t => t.Banca);
            var trabalhos = await _context.Trabalhos.Include(t => t.Banca).ToListAsync();
            return View(await bancaTCCContext.ToListAsync());
        }

        // GET: Trabalho/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabalho = await _context.Trabalhos
                .Include(t => t.Autor)
                .Include(t => t.Banca)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trabalho == null)
            {
                return NotFound();
            }

            return View(trabalho);
        }

        // GET: Trabalho/Create
        public IActionResult Create()
        {
            ViewData["AutorId"] = new SelectList(_context.Autores, "Id", "Nome");
            return View();
        }

        // POST: Trabalho/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TrabalhoTema,TrabalhoArea,TrabalhoLink,TrabalhoGitLink,AutorId")] Trabalho trabalho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trabalho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorId"] = new SelectList(_context.Autores, "Id", "Nome", trabalho.AutorId);
            return View(trabalho);
        }

        // GET: Trabalho/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabalho = await _context.Trabalhos.FindAsync(id);
            if (trabalho == null)
            {
                return NotFound();
            }
            ViewData["AutorId"] = new SelectList(_context.Autores, "Id", "Nome", trabalho.AutorId);
            ViewData["Id"] = new SelectList(_context.Bancas, "Id", "Id", trabalho.Id);
            return View(trabalho);
        }

        // POST: Trabalho/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TrabalhoTema,TrabalhoArea,TrabalhoLink,TrabalhoGitLink,AutorId")] Trabalho trabalho)
        {
            if (id != trabalho.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trabalho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrabalhoExists(trabalho.Id))
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
            ViewData["AutorId"] = new SelectList(_context.Autores, "Id", "Nome", trabalho.AutorId);
            ViewData["Id"] = new SelectList(_context.Bancas, "Id", "Id", trabalho.Id);
            return View(trabalho);
        }

        // GET: Trabalho/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabalho = await _context.Trabalhos
                .Include(t => t.Autor)
                .Include(t => t.Banca)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trabalho == null)
            {
                return NotFound();
            }

            return View(trabalho);
        }

        // POST: Trabalho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trabalho = await _context.Trabalhos.FindAsync(id);
            if (trabalho != null)
            {
                _context.Trabalhos.Remove(trabalho);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrabalhoExists(int id)
        {
            return _context.Trabalhos.Any(e => e.Id == id);
        }

    }
}
