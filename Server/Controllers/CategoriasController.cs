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
   public class CategoriasController : ControllerBase
   {
      private PosDbContext _contexto;

      public CategoriasController(PosDbContext contexto)
      {
         _contexto = contexto;
      }
      // GET: api/<CategoriasController>
      [HttpGet]
      public IEnumerable<Categoria> Get()
      {
         return _contexto.Categorias.ToList();
      }

      // GET api/<CategoriasController>/5
      [HttpGet("{id}")]
      public async Task<Categoria> Get(int id)
      {
         return await _contexto.Categorias.Where(r => r.Id == id).FirstOrDefaultAsync();
      }

      // POST api/<CategoriasController>
      [HttpPost]
      public async Task<ActionResult> Post([FromBody] Categoria categoria)
      {
         _contexto.Add(categoria);
         await _contexto.SaveChangesAsync();
         return NoContent();
      }

      // PUT api/<CategoriasController>/5
      [HttpPut("{id}")]
      public async Task<ActionResult> Put(int id, [FromBody] Categoria categoria)
      {
         _contexto.Entry(categoria).State = EntityState.Modified; 
         await _contexto.SaveChangesAsync();
         return NoContent();
      }

      // DELETE api/<ValuesController>/5
      [HttpDelete("{id}")]
      public async Task<ActionResult> Delete(int id)
      {
         Categoria laCategoria = new Categoria() { Id = id };
         _contexto.Categorias.Remove(laCategoria);
         await _contexto.SaveChangesAsync();
         return NoContent();
      }
   }
}
