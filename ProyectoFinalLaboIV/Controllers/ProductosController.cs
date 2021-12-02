using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalLaboIV.Data;
using ProyectoFinalLaboIV.Models;
using ProyectoFinalLaboIV.Models.ViewModels;

namespace ProyectoFinalLaboIV.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env; //va a traer los datos del servidor

        public ProductosController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Productos
        public IActionResult Index(string buscarNombre, int? filtrarMarca, int? filtrarCateg)
        {
            var applicationDbContext = _context.Products.Include(p => p.CategoriaProducto).Include(p => p.MarcaProducto).Select(p => p);

            if (!string.IsNullOrEmpty(buscarNombre))
            {
                applicationDbContext = applicationDbContext.Where(x => x.Nombre.Contains(buscarNombre));
            }
            if (filtrarMarca.HasValue)
            {
                applicationDbContext = applicationDbContext.Where(x => x.MarcaId == filtrarMarca.Value);
            }
            if (filtrarCateg.HasValue)
            {
                applicationDbContext = applicationDbContext.Where(x => x.CategoriaId == filtrarCateg.Value);
            }


            ProductosViewModel model = new ProductosViewModel()
            {
                Productos = applicationDbContext.ToList(),
                Marcas = new SelectList(_context.Marcas, "Id", "Nombre", filtrarMarca),
                Categorias = new SelectList(_context.Categorias, "Id", "Descripcion", filtrarCateg),
                Nombre = buscarNombre,
                MarcaId = filtrarMarca,
                CategId = filtrarCateg
            };

            return View(model);
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Products
                .Include(p => p.CategoriaProducto)
                .Include(p => p.MarcaProducto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }
        [Authorize]
        // GET: Productos/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Descripcion");
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Nombre");
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Precio,Descripcion,MarcaId,CategoriaId,Imagen,Favorito")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                imageUpload(producto);
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Descripcion", producto.CategoriaId);
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Nombre", producto.MarcaId);
            return View(producto);
        }
        [Authorize]
        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Products.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Descripcion", producto.CategoriaId);
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Nombre", producto.MarcaId);
            return View(producto);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Precio,Descripcion,MarcaId,CategoriaId,Imagen,Favorito")] Producto producto)
        {
            if (id != producto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    imageUpload(producto);
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.Id))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Descripcion", producto.CategoriaId);
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Nombre", producto.MarcaId);
            return View(producto);
        }
        [Authorize]
        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Products
                .Include(p => p.CategoriaProducto)
                .Include(p => p.MarcaProducto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = await _context.Products.FindAsync(id);
            _context.Products.Remove(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
        private void imageUpload(Producto producto)
        {
            var files = HttpContext.Request.Form.Files; //la clase HttpContext devuelve una coleccion de archivos, que toma desde el form
            if (files != null && files.Count > 0) //validamos que la coleccion no sea nula y tenga archivos
            {
                var archivoImagen = files[0]; //como sabemos que vamos a subir una sola imagen, la guardamos en image con el indice 0 de la coleccion

                if (archivoImagen.Length > 0)
                {
                    var pathDestino = Path.Combine(_env.WebRootPath, "images\\productos"); // crea un string que contiene la ruta donde voy a guardr la imagen
                                                                                         //Generamos un hash (nombre aleatorio) para cambiar el nombre del arhivo, y lo guardamos como string
                    var archivoDestino = Guid.NewGuid().ToString().Replace("-", ""); // quitamos los guiones
                    archivoDestino += Path.GetExtension(archivoImagen.FileName); //le concatenamos la extension del archivo
                                                                                 //concatenamos el path de destino y el nombre del archivo
                    var rutaDestino = Path.Combine(pathDestino, archivoDestino);

                    using (var filestream = new FileStream(rutaDestino, FileMode.Create)) //cuando termina el using libera los recursos que se utilizan dentro
                    {
                        //copiamos el archivo a nuestro directorio en el servidor
                        archivoImagen.CopyTo(filestream);
                        producto.Imagen = archivoDestino;
                    }
                }
            }
        }
    }
}
