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
        // POST: MembroExterior/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Telefone,Email")] MembroExterior membroExterior)
        {
            if (ModelState.IsValid)
            {
                // Verifica se já existe um membro com o mesmo email
                var emailExistente3 = await _context.MembrosExternos
                    .FirstOrDefaultAsync(a => a.Email == membroExterior.Email);
                if (emailExistente3 != null)
                {
                    ModelState.AddModelError("Email", "Já existe um membro com esse email.");
                }

                // Verifica se já existe um membro com o mesmo telefone
                var telefoneExistente = await _context.MembrosExternos
                    .FirstOrDefaultAsync(a => a.Telefone == membroExterior.Telefone);
                if (telefoneExistente != null)
                {
                    ModelState.AddModelError("Telefone", "Já existe um membro com esse telefone.");
                }

                // Se não houver erros, salva o novo membro
                if (ModelState.IsValid)
                {
                    _context.Add(membroExterior);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
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
                    // Verifica se já existe um membro com o mesmo email, mas ignorando o próprio membro
                    var emailExistente = await _context.MembrosExternos
                        .FirstOrDefaultAsync(a => a.Email == membroExterior.Email && a.Id != membroExterior.Id);
                    if (emailExistente != null)
                    {
                        ModelState.AddModelError("Email", "Já existe um membro com esse email.");
                    }

                    // Verifica se já existe um membro com o mesmo telefone, mas ignorando o próprio membro
                    var telefoneExistente = await _context.MembrosExternos
                        .FirstOrDefaultAsync(a => a.Telefone == membroExterior.Telefone && a.Id != membroExterior.Id);
                    if (telefoneExistente != null)
                    {
                        ModelState.AddModelError("Telefone", "Já existe um membro com esse telefone.");
                    }

                    // Se não houver erros, atualiza o membro
                    if (ModelState.IsValid)
                    {
                        _context.Update(membroExterior);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
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
