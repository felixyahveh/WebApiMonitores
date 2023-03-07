using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiMonitores.Entidades;

namespace WebApiMonitores.Controllers
{
    [ApiController]
    [Route("provedores")]
    public class ProvedorController:ControllerBase
    {
        private readonly ApplicationDbContext dbcontext;

        public ProvedorController(ApplicationDbContext context)
        {
            this.dbcontext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Provedor>>> GetAll()
        {
            return await dbcontext.Provedores.Include(x => x.Monitores).ToListAsync();   
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Provedor>> GetById(int id)
        {
            return await dbcontext.Provedores.Include(x => x.Monitores).FirstOrDefaultAsync(p => p.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Provedor pro)
        {
            dbcontext.Add(pro);
            await dbcontext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Provedor pro, int id)
        {
            var exist = await dbcontext.Provedores.AnyAsync(p => p.Id == id);
            if (!exist)
            {
                return NotFound("No se encontro el provedor en la base de datos");
            }

            if (pro.Id != id)
            {
                return BadRequest("El id de la URL no coincide con el objeto");
            }

            dbcontext.Update(pro);
            await dbcontext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbcontext.Provedores.AnyAsync(p => p.Id == id);
            if (!exist)
            {
                return NotFound("No se encontro el provedor en la base de datos");
            }
            dbcontext.Remove( new Provedor () { Id = id });
            await dbcontext.SaveChangesAsync ();
            return Ok();


        }

    }
}
