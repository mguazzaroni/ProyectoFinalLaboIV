using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalLaboIV.Models
{
    public class Producto
    {
        public int Id { get; set; }
        [Display(Name = "Nombre del Producto")]
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }
        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El precio es requerido")]
        public float Precio { get; set; }
        [Display(Name = "Descripción del producto")]
        [Required(ErrorMessage = "La desripcion es requerida")]
        public string Descripcion { get; set; }
        [Display(Name = "Marca")]
        public int MarcaId { get; set; }
        [Display(Name = "Categoría")]
        public int CategoriaId { get; set; }
        [Display(Name = "Imagen del producto")]
        public string Imagen { get; set; }
        public bool Favorito { get; set; }
        [Display(Name = "Marca")]
        public Marca MarcaProducto { get; set; }
        [Display(Name = "Categoria")]
        public Categoria CategoriaProducto { get; set; }
        
    }
}
