using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudFilmes.Data;
using CrudFilmes.Models;

namespace CrudFilmes.Controllers
{
    public class CadastFilmesController : Controller
    {
        private readonly CrudFilmesContext _context;

        public CadastFilmesController(CrudFilmesContext context)
        {
            _context = context;
        }

        // GET: CadastFilmes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CadastFilmes.ToListAsync());
        }

        // GET: CadastFilmes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastFilmes = await _context.CadastFilmes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastFilmes == null)
            {
                return NotFound();
            }

            return View(cadastFilmes);
        }

        // GET: CadastFilmes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadastFilmes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genero,Preco")] CadastFilmes cadastFilmes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastFilmes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastFilmes);
        }

        // GET: CadastFilmes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastFilmes = await _context.CadastFilmes.FindAsync(id);
            if (cadastFilmes == null)
            {
                return NotFound();
            }
            return View(cadastFilmes);
        }

        // POST: CadastFilmes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genero,Preco")] CadastFilmes cadastFilmes)
        {
            if (id != cadastFilmes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastFilmes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastFilmesExists(cadastFilmes.Id))
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
            return View(cadastFilmes);
        }

        // GET: CadastFilmes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastFilmes = await _context.CadastFilmes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastFilmes == null)
            {
                return NotFound();
            }

            return View(cadastFilmes);
        }

        // POST: CadastFilmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastFilmes = await _context.CadastFilmes.FindAsync(id);
            _context.CadastFilmes.Remove(cadastFilmes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastFilmesExists(int id)
        {
            return _context.CadastFilmes.Any(e => e.Id == id);
        }
    }
}
