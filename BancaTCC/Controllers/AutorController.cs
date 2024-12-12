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
    public class AutorController : Controller
    {
        private readonly BancaTCCContext _context;

        public AutorController(BancaTCCContext context)
        {
            _context = context;
        }

        // GET: Autor
        public async Task<IActionResult> Index()
        {
            var bancaTCCContext = _context.Autores.Include(a => a.Curso);
            return View(await bancaTCCContext.ToListAsync());
        }

        // GET: Autor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _context.Autores
                .Include(a => a.Curso)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        // GET: Autor/Create
        public IActionResult Create()
        {
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Nome");
            return View();
        }

        // POST: Autor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Matricula,Email,CursoId")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                // Verifica se já existe um autor com o mesmo email
                var emailExistente = await _context.Autores
                    .FirstOrDefaultAsync(a => a.Email == autor.Email);
                if (emailExistente != null)
                {
                    ModelState.AddModelError("Email", "Já existe um autor com esse email.");
                }

                // Verifica se já existe um autor com a mesma matrícula
                var matriculaExistente = await _context.Autores
                    .FirstOrDefaultAsync(a => a.Matricula == autor.Matricula);
                if (matriculaExistente != null)
                {
                    ModelState.AddModelError("Matricula", "Já existe um autor com essa matrícula.");
                }

                // Se houver erros de validação, retorna a view
                if (!ModelState.IsValid)
                {
                    ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Nome", autor.CursoId);
                    return View(autor);
                }

                _context.Add(autor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Nome", autor.CursoId);
            return View(autor);
        }



        // GET: Autor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _context.Autores.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Nome", autor.CursoId);
            return View(autor);
        }

        // POST: Autor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Matricula,Email,CursoId")] Autor autor)
        {
            if (id != autor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutorExists(autor.Id))
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
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Nome", autor.CursoId);
            return View(autor);
        }

        // GET: Autor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _context.Autores
                .Include(a => a.Curso)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        // POST: Autor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autor = await _context.Autores.FindAsync(id);
            if (autor != null)
            {
                _context.Autores.Remove(autor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutorExists(int id)
        {
            return _context.Autores.Any(e => e.Id == id);
        }
    }
}
