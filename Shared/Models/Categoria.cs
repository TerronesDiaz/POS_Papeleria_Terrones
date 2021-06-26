using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS_Papeleria_Terrones.Shared.Models
{
   public class Categoria
   {
      public int Id { get; set; }
      [Required(ErrorMessage = "El nombre de categoría no puede estar vacío")]
      public string Nombre { get; set; }
      //public ICollection<Articulo> Articulos { get; set; }
   }
}
