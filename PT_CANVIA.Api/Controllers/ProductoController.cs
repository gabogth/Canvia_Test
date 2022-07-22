using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PT_CANVIA.Aplicacion.Handlers;
using PT_CANVIA.Aplicacion.Request;

namespace PT_CANVIA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ILogger<ProductoController> oLogger;
        public ProductoController(ILogger<ProductoController> oLogger)
        {
            this.oLogger = oLogger;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int? nProducto_Id, string? cQuery)
        {
            try
            {
                ProductoHandler oProductoHandler = new ProductoHandler();
                return Ok(await oProductoHandler.GetDatosAsync(new ProductoGetDatos { nProducto_Id = nProducto_Id, cQuery = cQuery }));
            }
            catch (Exception oException)
            {
                string cMessage = oException.Message ?? oException.InnerException!.Message;
                oLogger.LogError(cMessage);
                return BadRequest(new { Error = cMessage });
            }
        }

        [HttpGet("{nProducto_Id}")]
        public async Task<IActionResult> GetById(int nProducto_Id)
        {
            try
            {
                ProductoHandler oProductoHandler = new ProductoHandler();
                return Ok(await oProductoHandler.GetPorIdAsync(new ProductoGetPorId { nProducto_Id = nProducto_Id }));
            }
            catch (Exception oException)
            {
                string cMessage = oException.Message ?? oException.InnerException!.Message;
                oLogger.LogError(cMessage);
                return BadRequest(new { Error = cMessage });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductoGrabar oProductoRequest)
        {
            try
            {
                ProductoHandler oProductoHandler = new ProductoHandler();
                return Ok(await oProductoHandler.GrabarAsync(oProductoRequest));
            }
            catch (Exception oException)
            {
                string cMessage = oException.Message ?? oException.InnerException!.Message;
                oLogger.LogError(cMessage);
                return BadRequest(new { Error = cMessage });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int nProducto_Id)
        {
            try
            {
                ProductoHandler oProductoHandler = new ProductoHandler();
                await oProductoHandler.EliminarAsync(new ProductoEliminar { nProducto_Id = nProducto_Id });
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
