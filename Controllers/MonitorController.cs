using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiMonitores.Entidades;
using Monitor = WebApiMonitores.Entidades.Monitor;

namespace WebApiMonitores.Controllers
{
    [ApiController]
    [Route("monitores")]
    public class MonitorController: ControllerBase
    {
        private readonly ApplicationDbContext dbcontext;

        public MonitorController(ApplicationDbContext context)
        {
            this.dbcontext = context;
        }

        [HttpGet]
        public ActionResult <List<Monitor>> Get()
        {
            return new List<Monitor> ()
            {
                new Monitor() { Id = 1, Descripcion="Monitor LED", Modelo="DELL459482",Nombre="Monitor DELL 500",Precio=5050.50f},
                new Monitor() { Id = 2, Descripcion="Monitor Amoled",Modelo="Samsung_49183",Nombre="Monitor Samsung 491",Precio=10599.99f}
            };
        }

        [HttpPost]
        public async Task <ActionResult> Post(Monitor mon)
        {
            var exist = await dbcontext.Provedores.AnyAsync(p => p.Id == mon.ProvedorId);
            if (!exist) {
                return BadRequest($"No existe el provedor con id: {mon.ProvedorId}");
            }
            dbcontext.Add(mon);
            await dbcontext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("/lista")]
        public async Task <ActionResult<List<Monitor>>> GetAll()
        {
            return await dbcontext.Monitores.ToListAsync();
        }

        [HttpPut("{id:int}")]
        public async Task <ActionResult> Put(Monitor mon, int id)
        {
            var ex = await dbcontext.Monitores.AnyAsync(p => p.Id == id);
            if (!ex)
            {
                return NotFound("No se encontro el provedor en la base de datos");
            }

            var exist = await dbcontext.Provedores.AnyAsync(p => p.Id == mon.ProvedorId);
            if (!exist)
            {
                return BadRequest($"No existe el provedor con id: {mon.ProvedorId}");
            }

            if (mon.Id != id)
            {
                return BadRequest("El id del monitor no coincide con el establecido con el de la URL");
            }

            dbcontext.Update(mon);
            await dbcontext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete (int id)
        {
            var exist = await dbcontext.Monitores.AnyAsync(mon => mon.Id == id);

            if (!exist)
            {
                return NotFound("El id no se encontro con la base de datos");
            }

            dbcontext.Remove(new Monitor () { Id = id });
            await dbcontext.SaveChangesAsync();
            return Ok();
        }

    }

}