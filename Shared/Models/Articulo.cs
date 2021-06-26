using POS_Papeleria_Terrones.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS_Papeleria_Terrones.Shared.Models
{
   public class Articulo
   {
      public int Id { get; set; }
      [Required(ErrorMessage = "El nombre del artículo no puede estar vacío")]
      public string Nombre { get; set; }
      [Range(1, int.MaxValue, ErrorMessage = "El precio debe ser mayor que 0")]
      public double Precio { get; set; }
      [Range(1, int.MaxValue, ErrorMessage = "El costo debe ser mayor que 0")]
      public double Costo { get; set; }
      [Range(0, int.MaxValue, ErrorMessage = "La existencia debe ser mayor o igual que 0")]
      public int Existencia { get; set; }
      public int CategoriaId { get; set; }
      public Categoria Categoria { get; set; }
   }
}

