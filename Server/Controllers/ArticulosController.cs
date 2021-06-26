using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS_Papeleria_Terrones.Server.Data;
using POS_Papeleria_Terrones.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace POS_Papeleria_Terrones.Server.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class ArticulosController : ControllerBase
   {
      private PosDbContext _contexto;

      public ArticulosController(PosDbContext contexto) 
      {
         _contexto = contexto;
      }
      // GET: api/<ArticulosController>
      [HttpGet]
      public IEnumerable<Articulo> Get()
      {
         return _contexto.Articulos.Include(d => d.Categoria).ToList();
      }

      // GET api/<ArticulosController>/5
      [HttpGet("{id}")]
      public async Task<Articulo> Get(int id)
      {
         return await _contexto.Articulos.Where(r => r.Id == id).FirstOrDefaultAsync();
      }

      // POST api/<ArticulosController>
      [HttpPost]
      public async Task<ActionResult> Post([FromBody] Articulo articulo)
      {
         _contexto.Add(articulo);
         await _contexto.SaveChangesAsync();
         return NoContent();
      }

      // POST api/<ArticulosEntradaController>
      [HttpPost("entradas")]
      public async Task<ActionResult> PostEntradas([FromBody] Entrada entrada)
      {
         _contexto.Add(entrada);
         var elarticulo = _contexto.Articulos.Where(r => r.Id == entrada.ArticuloId).FirstOrDefault();
         if (elarticulo!=null) 
         {
            elarticulo.Existencia += entrada.Cantidad;
         }
         await _contexto.SaveChangesAsync();
         return NoContent();
      }
      // POST api/<ArticulosSalidaController>
      [HttpPost("salidas")]
      public async Task<ActionResult> PostSalidas([FromBody] Salida salida)
      {
         _contexto.Add(salida);
         var elarticulo = _contexto.Articulos.Where(r => r.Id == salida.ArticuloId).FirstOrDefault();
         if (elarticulo != null)
         {
            elarticulo.Existencia -= salida.Cantidad;
         }
         await _contexto.SaveChangesAsync();
         return NoContent();
      }

      // PUT api/<CategoriasController>/5
      [HttpPut()]
      public async Task<ActionResult> Put([FromBody] Articulo articulo)
      {
         _contexto.Entry(articulo).State = EntityState.Modified;
         await _contexto.SaveChangesAsync();
         return NoContent();
      }

      // DELETE api/<ValuesController>/5
      [HttpDelete("{id}")]
      public async Task<ActionResult> Delete(int id)
      {
         Articulo elArticulo = new Articulo() { Id = id };
         _contexto.Articulos.Remove(elArticulo);
         await _contexto.SaveChangesAsync();
         return NoContent();
      }
   }
}
