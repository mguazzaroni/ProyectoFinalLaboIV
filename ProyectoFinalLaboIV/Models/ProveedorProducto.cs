using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalLaboIV.Models
{
    public class ProveedorProducto
    {
        [Display(Name="Proveedor")]
        public int ProveedorId { get; set; }
        [Display(Name = "Producto")]
        public int ProductoId { get; set; }
        public Proveedor Proveedor{ get; set; }
        public Producto Producto { get; set; }
    }
}
