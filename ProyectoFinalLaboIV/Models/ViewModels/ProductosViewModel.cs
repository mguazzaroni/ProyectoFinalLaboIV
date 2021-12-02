using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalLaboIV.Models.ViewModels
{
    public class ProductosViewModel
    {
        public List<Producto> Productos { get; set; }
        public SelectList Marcas { get; set; }
        public SelectList Categorias { get; set; }
        public string Nombre { get; set; }
        public int? MarcaId { get; set; }
        public int? CategId { get; set; }
    }
}
