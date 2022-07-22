using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PT_CANVIA.Core.Entidades.Ventas;
using PT_CANVIA.Aplicacion.Handlers;
using PT_CANVIA.Aplicacion.Request;

namespace PT_CANVIA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlmacenController : ControllerBase
    {
        private readonly ILogger<AlmacenController> oLogger;
        public AlmacenController(ILogger<AlmacenController> oLogger)
        {
            this.oLogger = oLogger;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int? nAlmacen_Id, string? cQuery)
        {
            try
            {
                AlmacenHandler oAlmacenHandler = new AlmacenHandler();
                return Ok(await oAlmacenHandler.GetDatosAsync(new AlmacenGetDatos { nAlmacen_Id = nAlmacen_Id, cQuery = cQuery }));
            }
            catch (Exception oException)
            {
                string cMessage = oException.Message ?? oException.InnerException!.Message;
                oLogger.LogError(cMessage);
                return BadRequest(new { Error = cMessage });
            }
        }

        [HttpGet("{nAlmacen_Id}")]
        public async Task<IActionResult> GetById(int nAlmacen_Id)
        {
            try
            {
                AlmacenHandler oAlmacenHandler = new AlmacenHandler();
                return Ok(await oAlmacenHandler.GetPorIdAsync(new AlmacenGetPorId { nAlmacen_Id = nAlmacen_Id}));
            }
            catch (Exception oException)
            {
                string cMessage = oException.Message ?? oException.InnerException!.Message;
                oLogger.LogError(cMessage);
                return BadRequest(new { Error = cMessage });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(AlmacenGrabar oAlmacenRequest)
        {
            try
            {
                AlmacenHandler oAlmacenHandler = new AlmacenHandler();
                return Ok(await oAlmacenHandler.GrabarAsync(oAlmacenRequest));
            }
            catch (Exception oException)
            {
                string cMessage = oException.Message ?? oException.InnerException!.Message;
                oLogger.LogError(cMessage);
                return BadRequest(new { Error = cMessage });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int nAlmacen_Id)
        {
            try
            {
                AlmacenHandler oAlmacenHandler = new AlmacenHandler();
                await oAlmacenHandler.EliminarAsync(new AlmacenEliminar { nAlmacen_Id = nAlmacen_Id });
                return Ok(true);
            }
            catch (Exception oException)
            {
                string cMessage = oException.Message ?? oException.InnerException!.Message;
                oLogger.LogError(cMessage);
                return BadRequest(new { Error = cMessage });
            }
        }
    }
}
