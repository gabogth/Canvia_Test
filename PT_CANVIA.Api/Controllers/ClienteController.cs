using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PT_CANVIA.Aplicacion.Handlers;
using PT_CANVIA.Aplicacion.Request;

namespace PT_CANVIA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> oLogger;
        public ClienteController(ILogger<ClienteController> oLogger)
        {
            this.oLogger = oLogger;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int? nCliente_Id, string? cQuery)
        {
            try
            {
                ClienteHandler oClienteHandler = new ClienteHandler();
                return Ok(await oClienteHandler.GetDatosAsync(new ClienteGetDatos { nCliente_Id = nCliente_Id, cQuery = cQuery }));
            }
            catch (Exception oException)
            {
                string cMessage = oException.Message ?? oException.InnerException!.Message;
                oLogger.LogError(cMessage);
                return BadRequest(new { Error = cMessage });
            }
        }

        [HttpGet("{nCliente_Id}")]
        public async Task<IActionResult> GetById(int nCliente_Id)
        {
            try
            {
                ClienteHandler oClienteHandler = new ClienteHandler();
                return Ok(await oClienteHandler.GetPorIdAsync(new ClienteGetPorId { nCliente_Id = nCliente_Id }));
            }
            catch (Exception oException)
            {
                string cMessage = oException.Message ?? oException.InnerException!.Message;
                oLogger.LogError(cMessage);
                return BadRequest(new { Error = cMessage });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClienteGrabar oClienteRequest)
        {
            try
            {
                ClienteHandler oClienteHandler = new ClienteHandler();
                return Ok(await oClienteHandler.GrabarAsync(oClienteRequest));
            }
            catch (Exception oException)
            {
                string cMessage = oException.Message ?? oException.InnerException!.Message;
                oLogger.LogError(cMessage);
                return BadRequest(new { Error = cMessage });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int nCliente_Id)
        {
            try
            {
                ClienteHandler oClienteHandler = new ClienteHandler();
                await oClienteHandler.EliminarAsync(new ClienteEliminar { nCliente_Id = nCliente_Id });
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
