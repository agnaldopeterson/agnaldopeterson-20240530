﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using rteCRUD.Data;
using rteCRUD.Models;

namespace rteCRUD.Controllers
{
    public class ColaboradorController : Controller
    {
        private readonly Contexto _context;

        public ColaboradorController(Contexto context)
        {
            _context = context;
        }

        // GET: Colaborador
        public async Task<IActionResult> Index()
        {
            var colaboradores = _context.Colaboradores
                .Include(c => c.Unidade)
                .Include(c => c.Codigo);
            return View(await _context.Colaboradores.ToListAsync());
        }

        // GET: Colaborador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaboradorModel = await _context.Colaboradores
                .Include (c => c.Unidade)
                .Include (c => c.Codigo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (colaboradorModel == null)
            {
                return NotFound();
            }

            return View(colaboradorModel);
        }

        // GET: Colaborador/Create
        public IActionResult Create()
        {
            PreencherDropdowns();
            return View();
        }

        // POST: Colaborador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Nome,UnidadeId,UsuarioId")] ColaboradorModel colaboradorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colaboradorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PreencherDropdowns(colaboradorModel.UnidadeId,colaboradorModel.UsuarioId);
            return View(colaboradorModel);
        }

        // GET: Colaborador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaboradorModel = await _context.Colaboradores.FindAsync(id);
            if (colaboradorModel == null)
            {
                return NotFound();
            }
            return View(colaboradorModel);
        }

        // POST: Colaborador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,Nome,UnidadeId,UsuarioId")] ColaboradorModel colaboradorModel)
        {
            if (id != colaboradorModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colaboradorModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColaboradorModelExists(colaboradorModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }            
            }
            PreencherDropdowns(colaboradorModel.UnidadeId, colaboradorModel.UsuarioId);
            return View(colaboradorModel);
        }

        // GET: Colaborador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaboradorModel = await _context.Colaboradores
                .Include(c => c.Unidade)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (colaboradorModel == null)
            {
                return NotFound();
            }

            return View(colaboradorModel);
        }

        // POST: Colaborador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var colaboradorModel = await _context.Colaboradores.FindAsync(id);
            if (colaboradorModel != null)
            {
                _context.Colaboradores.Remove(colaboradorModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColaboradorModelExists(int id)
        {
            return _context.Colaboradores.Any(e => e.Id == id);
        }

        private void PreencherDropdowns(int? selectedUnidadeId = null, int? selectedUsuarioId = null)
        {
            var unidadesQuery = from u in _context.Unidades orderby u.Nome select u;
            var usuariosQuery = from u in _context.Usuarios orderby u.Login select u;

            ViewBag.Unidades = new SelectList(_context.Unidades.ToList(), "Id", "Nome", selectedUnidadeId);
            ViewBag.Usuarios = new SelectList(_context.Usuarios.ToList(), "Id", "Login", selectedUsuarioId);
        }
    }
}
