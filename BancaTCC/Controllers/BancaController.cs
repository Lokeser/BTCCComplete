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
    public class BancaController : Controller
    {
        private readonly BancaTCCContext _context;

        public BancaController(BancaTCCContext context)
        {
            _context = context;
        }

        // GET: Banca
        public async Task<IActionResult> Index()
        {
            var bancas = await _context.Bancas
                .Include(b => b.Comentarios) // Inclui os comentários associados à banca
                .Include(b => b.Professores)
                .Include(b => b.MembroExteriores)
                .ToListAsync();

            return View(bancas);
        }

        // GET: Banca/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banca = await _context.Bancas
                .Include(b => b.Comentarios)               // Carregar os comentários da banca
                    .ThenInclude(c => c.Professor)         // Carregar os professores dos comentários
                .Include(b => b.Professores)               // Carregar os professores da banca
                .Include(b => b.MembroExteriores)
                .FirstOrDefaultAsync(m => m.Id == id);


            if (banca == null)
            {
                return NotFound();
            }

            return View(banca);
        }

        // GET: Banca/Create
        public IActionResult Create()
        {
            ViewBag.TrabalhoId = new SelectList(_context.Trabalhos, "Id", "TrabalhoTema");
            ViewBag.Professores = _context.Professores.ToList();
            ViewBag.MembrosExterior = _context.MembrosExternos.ToList();
            return View();
        }


        // POST: Banca/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Banca banca, int[] professoresSelecionados, int[] membrosExteriorSelecionados)
        {
            // Validação: O número de professores selecionados deve ser entre 1 e 3
            if (professoresSelecionados.Length > 3)
            {
                ModelState.AddModelError("ProfessoresSelecionados", "Você deve selecionar no máximo 3 professores.");
            }

            if (ModelState.IsValid)
            {
                // Associar os professores selecionados à banca
                banca.Professores = _context.Professores
                    .Where(p => professoresSelecionados.Contains(p.Id))
                    .ToList();
                banca.MembroExteriores = _context.MembrosExternos
                    .Where(m => membrosExteriorSelecionados.Contains(m.Id))
                    .ToList();

                _context.Add(banca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Repopular a lista de professores em caso de erro
            ViewBag.Professores = _context.Professores.ToList();
            ViewBag.MembrosExterior = _context.MembrosExternos.ToList();
            ViewBag.TrabalhoId = new SelectList(_context.Trabalhos, "Id", "TrabalhoTema", banca.TrabalhoId);
            return View(banca);
        }


        // GET: Banca/Comentario
        public IActionResult Comentario(int id)
        {
            var professores = _context.Professores.ToList();
            if (professores == null || !professores.Any())
            {
                // Adiciona uma lógica para exibir uma mensagem de erro ou carregar um estado vazio
                ModelState.AddModelError("", "Nenhum professor encontrado. Por favor, adicione professores.");
            }

            // Converter a lista de professores para SelectListItem
            ViewBag.Professores = professores.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Nome
            }).ToList();

            var comentario = new Comentario
            {
                BancaId = id
            };

            return View(comentario);
        }



        // POST: Banca/Comentario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateComentario([Bind("BancaId,ProfessorId,Texto")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comentario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = comentario.BancaId });
            }

            var banca = await _context.Bancas.Include(b => b.Professores).FirstOrDefaultAsync(b => b.Id == comentario.BancaId);
            ViewBag.Professores = _context.Professores.ToList();
            return View("Comentario", comentario);
        }



        // GET: Banca/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banca = await _context.Bancas
                .Include(b => b.Professores)
                .Include(b => b.MembroExteriores)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (banca == null)
            {
                return NotFound();
            }

            ViewBag.TrabalhoId = new SelectList(_context.Trabalhos, "Id", "TrabalhoTema", banca.TrabalhoId);
            ViewBag.Professores = _context.Professores.ToList();
            ViewBag.MembrosExterior = _context.MembrosExternos.ToList();
            return View(banca);
        }

        // POST: Banca/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Banca banca, int[] professoresSelecionados, int[] membrosExteriorSelecionados)
        {
            if (id != banca.Id)
            {
                return NotFound();
            }

            // Validação: O número de professores selecionados deve ser entre 1 e 3
            if (professoresSelecionados.Length > 3)
            {
                ModelState.AddModelError("ProfessoresSelecionados", "Você deve selecionar no máximo 3 professores.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var bancaExistente = await _context.Bancas
                        .Include(b => b.Professores)
                        .Include(b => b.MembroExteriores)
                        .FirstOrDefaultAsync(b => b.Id == id);

                    if (bancaExistente == null)
                    {
                        return NotFound();
                    }

                    // Atualizar os professores selecionados
                    bancaExistente.Professores.Clear();
                    bancaExistente.MembroExteriores.Clear();
                    bancaExistente.Professores = _context.Professores
                        .Where(p => professoresSelecionados.Contains(p.Id))
                        .ToList();
                    bancaExistente.MembroExteriores = _context.MembrosExternos
                        .Where(m => membrosExteriorSelecionados.Contains(m.Id))
                        .ToList();

                    _context.Update(bancaExistente);
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

            ViewBag.Professores = _context.Professores.ToList();
            ViewBag.MembrosExterior = _context.MembrosExternos.ToList();
            ViewBag.TrabalhoId = new SelectList(_context.Trabalhos, "Id", "TrabalhoTema", banca.TrabalhoId);
            return View(banca);
        }

        // GET: Banca/Delete/5
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

        // POST: Banca/Delete/5
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
