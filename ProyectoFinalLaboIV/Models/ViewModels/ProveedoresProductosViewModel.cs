using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalLaboIV.Models.ViewModels
{
    public class ProveedoresProductosViewModel
    {
        public List<ProveedorProducto> ProveedoresProductos { get; set; }
        public SelectList Proveedores { get; set; }
        public SelectList Productos { get; set; }
        public int? ProveedorId { get; set; }
        public int? ProductoId { get; set; }
    }
}
