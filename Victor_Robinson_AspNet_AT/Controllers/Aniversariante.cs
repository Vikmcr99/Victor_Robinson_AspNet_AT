using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Victor_Robinson_AspNet_AT.Data;
using Victor_Robinson_AspNet_AT.Models;

namespace Victor_Robinson_AspNet_AT.Controllers
{
    public class Aniversariante : Controller
    {
        private readonly Victor_Robinson_AspNet_ATContext _context;

        public Aniversariante(Victor_Robinson_AspNet_ATContext context)
        {
            _context = context;
        }

        // GET: Aniversariantes
        public async Task<IActionResult> Index(string ordena, string pesquisa)
        {
            ViewData["OrdemNascimento"] = ordena == "DataCresc" ? "DataDecresc" : "DataCresc";
            ViewData["FiltoPesquisa"] = pesquisa;

            var aniversariantes = from a in _context.Aniversariante
                           select a;
            switch (ordena)
            {
                case "DataCresc":
                    aniversariantes = aniversariantes.OrderBy(a => a.Nascimento);
                    break;
                case "DataDecresc":
                    aniversariantes = aniversariantes.OrderByDescending(a => a.Nascimento);
                    break;
                default:
                    aniversariantes = aniversariantes.OrderBy(a => a.Id);
                    break;
            }

            if (!String.IsNullOrEmpty(pesquisa))
            {
                aniversariantes = aniversariantes.Where(s => s.Nome.Contains(pesquisa) || s.Sobrenome.Contains(pesquisa));
            }
           
            return View(await aniversariantes.ToListAsync());
        }

        //return View(await _context.Aniversariante.ToListAsync());
        // GET: Aniversariantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aniversariante = await _context.Aniversariante
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aniversariante == null)
            {
                return NotFound();
            }

            return View(aniversariante);
        }

        // GET: Aniversariantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aniversariantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sobrenome,Nascimento")] Models.Aniversariante aniversariante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aniversariante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aniversariante);
        }

        // GET: Aniversariantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aniversariante = await _context.Aniversariante.FindAsync(id);
            if (aniversariante == null)
            {
                return NotFound();
            }
            return View(aniversariante);
        }

        // POST: Aniversariantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Sobrenome,Nascimento")] Models.Aniversariante aniversariante)
        {
            if (id != aniversariante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aniversariante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AniversarianteExists(aniversariante.Id))
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
            return View(aniversariante);
        }

        // GET: Aniversariantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aniversariante = await _context.Aniversariante
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aniversariante == null)
            {
                return NotFound();
            }

            return View(aniversariante);
        }

        // POST: Aniversariantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aniversariante = await _context.Aniversariante.FindAsync(id);
            _context.Aniversariante.Remove(aniversariante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AniversarianteExists(int id)
        {
            return _context.Aniversariante.Any(e => e.Id == id);
        }

        public async Task<IActionResult> AniversarioDoDia()
        {
            DateTime hoje = DateTime.Today;
            var aniversarianteDia = await _context.Aniversariante.ToListAsync();


            foreach (var aniversariante in aniversarianteDia)
            {
                if (aniversariante.Nascimento.Day == hoje.Day && aniversariante.Nascimento.Month == hoje.Month)
                {
                    //await _context.Aniversariante.FindAsync(aniversariante);
                    Models.Aniversariante.Salvar(aniversariante);
                }
                
            }

            return View(Models.Aniversariante.listaAniversariante);

        }

      
    }
}
