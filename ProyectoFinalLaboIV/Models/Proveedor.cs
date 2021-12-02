using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalLaboIV.Models
{
    public class Proveedor
    {
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }
        [Display(Name = "Numero de telefono")]
        [Required(ErrorMessage = "El telefono es requerido")]
        public string Telefono { get; set; }
        [Display(Name = "Direccion")]
        [Required(ErrorMessage = "La direccion es requerida")]
        public string Direccion { get; set; }
        [Display(Name = "Localidad")]
        [Required(ErrorMessage = "La localidad es requerida")]
        public string Localidad { get; set; }
        [Display(Name = "Provincia")]
        [Required(ErrorMessage = "La provincia es requerida")]
        public string Provincia { get; set; }
        public List<Producto> productos { get; set; }
    }
}
