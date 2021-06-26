using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS_Papeleria_Terrones.Shared.Models
{
   public class Entrada
   {
      public int Id{ get; set; }
      [Required(ErrorMessage = "La nota es obligatoria")]
      public string Nota { get; set; }
      public DateTime Fecha { get; set; }
      [Range(1,int.MaxValue, ErrorMessage ="La cantidad debe ser mayor o igual a 1")]
      public int Cantidad { get; set; }
      public int ArticuloId { get; set; }
      public int Articulo { get; set; }

   }
}
