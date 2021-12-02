using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalLaboIV.Data;
using ProyectoFinalLaboIV.Models;
using ProyectoFinalLaboIV.Models.ViewModels;

namespace ProyectoFinalLaboIV.Controllers
{
    public class ProveedoresProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProveedoresProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProveedoresProductos
        public IActionResult Index(int? busquedaProv, int? busquedaProd)
        {
            var applicationDbContext = _context.ProveedoresProductos.Include(p => p.Proveedor).Include(p => p.Producto).Select(p => p);
            //var applicationDbContext = _context.ProveedoresProductos.Include(p => p.Producto).Include(p => p.Proveedor);

            if (busquedaProv.HasValue)
            {
                applicationDbContext = applicationDbContext.Where(x => x.ProveedorId == busquedaProv);
            }
            if (busquedaProd.HasValue)
            {
                applicationDbContext = applicationDbContext.Where(x => x.ProductoId == busquedaProd);
            }
            ProveedoresProductosViewModel model = new ProveedoresProductosViewModel()
            {
                ProveedoresProductos = applicationDbContext.ToList(),
                Proveedores = new SelectList(_context.Proveedores, "Id", "Nombre", busquedaProv),
                Productos = new SelectList(_context.Products, "Id", "Nombre", busquedaProd),
                ProveedorId = busquedaProv,
                ProductoId = busquedaProd
            };
            return View(model);
        }

        // GET: ProveedoresProductos/Details/5
        public async Task<IActionResult> Details(int? ProveedorId, int? ProductoId)
        {
            if (ProveedorId == null || ProductoId == null)
            {
                return NotFound();
            }
            var proveedorProducto = await _context.ProveedoresProductos
                .Include(p => p.Producto)
                .Include(p => p.Proveedor)
                .FirstOrDefaultAsync(m => m.ProveedorId == ProveedorId);
            if (proveedorProducto == null)
            {
                return NotFound();
            }

            return View(proveedorProducto);
        }

        // GET: ProveedoresProductos/Create
        public IActionResult Create()
        {
            ViewData["ProductoId"] = new SelectList(_context.Products, "Id", "Nombre");
            ViewData["ProveedorId"] = new SelectList(_context.Proveedores, "Id", "Nombre");
            return View();
        }

        // POST: ProveedoresProductos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProveedorId,ProductoId")] ProveedorProducto proveedorProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proveedorProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductoId"] = new SelectList(_context.Products, "Id", "Nombre", proveedorProducto.ProductoId);
            ViewData["ProveedorId"] = new SelectList(_context.Proveedores, "Id", "Nombre", proveedorProducto.ProveedorId);
            return View(proveedorProducto);
        }

        // GET: ProveedoresProductos/Edit/5
        public async Task<IActionResult> Edit(int? ProveedorId, int? ProductoId)
        {
            if (ProveedorId == null || ProductoId == null)
            {
                return NotFound();
            }

            var proveedorProducto = await _context.ProveedoresProductos.FindAsync(ProveedorId, ProductoId);
            
            if (proveedorProducto == null)
            {
                return NotFound();
            }
            ViewData["ProductoId"] = new SelectList(_context.Products, "Id", "Nombre", proveedorProducto.ProductoId);
            ViewData["ProveedorId"] = new SelectList(_context.Proveedores, "Id", "Nombre", proveedorProducto.ProveedorId);
            return View(proveedorProducto);
        }

        // POST: ProveedoresProductos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("ProveedorId,ProductoId")] ProveedorProducto proveedorProducto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proveedorProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProveedorProductoExists(proveedorProducto.ProveedorId))
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
            ViewData["ProductoId"] = new SelectList(_context.Products, "Id", "Nombre", proveedorProducto.ProductoId);
            ViewData["ProveedorId"] = new SelectList(_context.Proveedores, "Id", "Nombre", proveedorProducto.ProveedorId);
            return View(proveedorProducto);
        }

        // GET: ProveedoresProductos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedorProducto = await _context.ProveedoresProductos
                .Include(p => p.Producto)
                .Include(p => p.Proveedor)
                .FirstOrDefaultAsync(m => m.ProveedorId == id);
            if (proveedorProducto == null)
            {
                return NotFound();
            }

            return View(proveedorProducto);
        }

        // POST: ProveedoresProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proveedorProducto = await _context.ProveedoresProductos.FindAsync(id);
            _context.ProveedoresProductos.Remove(proveedorProducto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProveedorProductoExists(int id)
        {
            return _context.ProveedoresProductos.Any(e => e.ProveedorId == id);
        }
    }
}
