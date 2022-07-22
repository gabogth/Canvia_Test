using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PT_CANVIA.Aplicacion.Handlers;
using PT_CANVIA.Aplicacion.Request;

namespace PT_CANVIA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
        private readonly ILogger<TipoDocumentoController> oLogger;
        public TipoDocumentoController(ILogger<TipoDocumentoController> oLogger)
        {
            this.oLogger = oLogger;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int? nTipoDocumento_Id, string? cQuery)
        {
            try
            {
                TipoDocumentoHandler oTipoDocumentoHandler = new TipoDocumentoHandler();
                return Ok(await oTipoDocumentoHandler.GetDatosAsync(new TipoDocumentoGetDatos { nTipoDocumento_Id = nTipoDocumento_Id, cQuery = cQuery }));
            }
            catch (Exception oException)
            {
                string cMessage = oException.Message ?? oException.InnerException!.Message;
                oLogger.LogError(cMessage);
                return BadRequest(new { Error = cMessage });
            }
        }

        [HttpGet("{nTipoDocumento_Id}")]
        public async Task<IActionResult> GetById(int nTipoDocumento_Id)
        {
            try
            {
                TipoDocumentoHandler oTipoDocumentoHandler = new TipoDocumentoHandler();
                return Ok(await oTipoDocumentoHandler.GetPorIdAsync(new TipoDocumentoGetPorId { nTipoDocumento_Id = nTipoDocumento_Id }));
            }
            catch (Exception oException)
            {
                string cMessage = oException.Message ?? oException.InnerException!.Message;
                oLogger.LogError(cMessage);
                return BadRequest(new { Error = cMessage });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(TipoDocumentoGrabar oTipoDocumentoRequest)
        {
            try
            {
                TipoDocumentoHandler oTipoDocumentoHandler = new TipoDocumentoHandler();
                return Ok(await oTipoDocumentoHandler.GrabarAsync(oTipoDocumentoRequest));
            }
            catch (Exception oException)
            {
                string cMessage = oException.Message ?? oException.InnerException!.Message;
                oLogger.LogError(cMessage);
                return BadRequest(new { Error = cMessage });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int nTipoDocumento_Id)
        {
            try
            {
                TipoDocumentoHandler oTipoDocumentoHandler = new TipoDocumentoHandler();
                await oTipoDocumentoHandler.EliminarAsync(new TipoDocumentoEliminar { nTipoDocumento_Id = nTipoDocumento_Id });
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
