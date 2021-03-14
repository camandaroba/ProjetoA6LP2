using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dogs.Data;
using Dogs.Models;

namespace Dogs.Controllers
{
    public class CachorroController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CachorroController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cachorro
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cachorro.ToListAsync());
        }

        // GET: Cachorro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cachorro = await _context.Cachorro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cachorro == null)
            {
                return NotFound();
            }

            return View(cachorro);
        }

        // GET: Cachorro/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cachorro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Idade,Raca,Castracao,Genero,Vacinacao,Peso")] Cachorro cachorro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cachorro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cachorro);
        }

        // GET: Cachorro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cachorro = await _context.Cachorro.FindAsync(id);
            if (cachorro == null)
            {
                return NotFound();
            }
            return View(cachorro);
        }

        // POST: Cachorro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Idade,Raca,Castracao,Genero,Vacinacao,Peso")] Cachorro cachorro)
        {
            if (id != cachorro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cachorro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CachorroExists(cachorro.Id))
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
            return View(cachorro);
        }

        // GET: Cachorro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cachorro = await _context.Cachorro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cachorro == null)
            {
                return NotFound();
            }

            return View(cachorro);
        }

        // POST: Cachorro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cachorro = await _context.Cachorro.FindAsync(id);
            _context.Cachorro.Remove(cachorro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CachorroExists(int id)
        {
            return _context.Cachorro.Any(e => e.Id == id);
        }
    }
}
