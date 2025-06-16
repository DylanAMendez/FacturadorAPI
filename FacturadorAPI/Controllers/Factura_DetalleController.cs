using FacturadorAPI.Modelos;
using FacturadorAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FacturadorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Factura_DetalleController : ControllerBase
    {

        private readonly Factura_DetalleService _facturaDetalleService;

        public Factura_DetalleController(Factura_DetalleService factura_DetalleService)
        {
            _facturaDetalleService = factura_DetalleService;
        }

        [HttpGet("GetAllFacturaDetalle")]
        public List<Factura_Detalle> GetAllFacturaDetalle()
        {
            var lsAllFacturaDetalle = _facturaDetalleService.GetAllFacturaDetalle();

            Log.Information("GetAllFacturaDetalle : {@lsAllFacturaDetalle}", lsAllFacturaDetalle);

            return lsAllFacturaDetalle;
        }

        [HttpPost("AddFacturaDetalle")]
        public string AddFacturaDetalle([FromBody] Factura_Detalle facturaDetalle)
        {
            Log.Information("AddFacturaDetalle : {@facturaDetalle}", facturaDetalle);
            return _facturaDetalleService.AddFacturaDetalle(facturaDetalle);
        }

        [HttpPut("{IDActualizar}")]
        public string ActualizarFacturaDetalle(int IDActualizar, [FromBody] Factura_Detalle FacturaDetalle)
        {
            Log.Information("ActualizarFacturaDetalle : {@FacturaDetalle}", FacturaDetalle);
            return _facturaDetalleService.ActualizarFacturaDetalle(IDActualizar, FacturaDetalle);
        }

        [HttpDelete("{IDAEliminar}")]
        public string EliminarFacturaDetalle(int IDAEliminar)
        {
            Log.Information("EliminarFacturaDetalle : {@IDAEliminar}", IDAEliminar);
            return _facturaDetalleService.EliminarFacturaDetalle(IDAEliminar);
        }

        [HttpGet("{IDABuscar}")]
        public Factura_Detalle GetFacturaDetalleByID(int IDABuscar)
        {
            Log.Information("GetFacturaDetalleByID : {@IDABuscar}", IDABuscar);
            return _facturaDetalleService.GetFacturaDetalleByID(IDABuscar);
        }

    }
}
