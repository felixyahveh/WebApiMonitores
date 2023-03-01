using Microsoft.AspNetCore.Mvc;
using WebApiMonitores.Entidades;
using Monitor = WebApiMonitores.Entidades.Monitor;

namespace WebApiMonitores.Controllers
{
    [ApiController]
    [Route("api/monitores")]
    public class MonitorController: ControllerBase
    {
        [HttpGet]
        public ActionResult <List<Monitor>> Get()
        {
            return new List<Monitor> ()
            {
                new Monitor() { Id = 1, Descripcion="Monitor LED", Modelo="DELL459482",Nombre="Monitor DELL 500",Precio=5050.50f},
                new Monitor() { Id = 2, Descripcion="Monitor Amoled",Modelo="Samsung_49183",Nombre="Monitor Samsung 491",Precio=10599.99f}
            };
        }

    }
}