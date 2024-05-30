using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using rteCRUD.Data;
using rteCRUD.Models;

namespace rteCRUD.Controllers
{
    public class UnidadeController : Controller
    {
        private readonly Contexto _context;

        public UnidadeController(Contexto context)
        {
            _context = context;
        }

        // GET: UnidadeModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Unidades.ToListAsync());
        }

        // GET: UnidadeModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadeModel = await _context.Unidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unidadeModel == null)
            {
                return NotFound();
            }

            return View(unidadeModel);
        }

        // GET: UnidadeModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UnidadeModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Nome,Ativo")] UnidadeModel unidadeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidadeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unidadeModel);
        }

        // GET: UnidadeModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadeModel = await _context.Unidades.FindAsync(id);
            if (unidadeModel == null)
            {
                return NotFound();
            }
            return View(unidadeModel);
        }

        // POST: UnidadeModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,Nome,Ativo")] UnidadeModel unidadeModel)
        {
            if (id != unidadeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidadeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadeModelExists(unidadeModel.Id))
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
            return View(unidadeModel);
        }

        // GET: UnidadeModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadeModel = await _context.Unidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unidadeModel == null)
            {
                return NotFound();
            }

            return View(unidadeModel);
        }

        // POST: UnidadeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unidadeModel = await _context.Unidades.FindAsync(id);
            if (unidadeModel != null)
            {
                _context.Unidades.Remove(unidadeModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadeModelExists(int id)
        {
            return _context.Unidades.Any(e => e.Id == id);
        }
    }
}
