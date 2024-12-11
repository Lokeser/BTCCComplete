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
    public class CursoController : Controller
    {
        private readonly BancaTCCContext _context;

        public CursoController(BancaTCCContext context)
        {
            _context = context;
        }

        // GET: Curso
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cursos.ToListAsync());
        }

        // GET: Curso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.Cursos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // GET: Curso/Create
        public IActionResult Create()
        {
            // Lista de áreas sem ordem específica
            var areas = new List<string>
            {
                "Artes e Humanas",
                "Ciências Biológicas e de Saúde",
                "Ciências Exatas e Tecnológicas",
                "Ciências Sociais e Aplicadas",
                "Educação"
            };

            // Passando a lista de áreas para a view sem ordenação
            ViewData["Areas"] = areas;

            return View();
        }

        // POST: Curso/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Area,CargaHoraria")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(curso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Repassando as áreas para a view caso o modelo não seja válido
            var areas = new List<string>
            {
                "Artes e Humanas",
                "Ciências Biológicas e de Saúde",
                "Ciências Exatas e Tecnológicas",
                "Ciências Sociais e Aplicadas",
                "Educação"
            };

            ViewData["Areas"] = areas;

            return View(curso);
        }
        // GET: Curso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }
            return View(curso);
        }

        // POST: Curso/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Area,CargaHoraria")] Curso curso)
        {
            if (id != curso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoExists(curso.Id))
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
            return View(curso);
        }

        // GET: Curso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.Cursos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // POST: Curso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso != null)
            {
                _context.Cursos.Remove(curso);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursoExists(int id)
        {
            return _context.Cursos.Any(e => e.Id == id);
        }
    }
}
