using FacturadorAPI.Modelos;
using FacturadorAPI.Services;
using Microsoft.AspNetCore.Mvc;

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
            return _facturaDetalleService.GetAllFacturaDetalle();
        }

        [HttpPost("AddFacturaDetalle")]
        public string AddFacturaDetalle([FromBody] Factura_Detalle facturaDetalle)
        {
            return _facturaDetalleService.AddFacturaDetalle(facturaDetalle);
        }

        [HttpPut("{IDActualizar}")]
        public string ActualizarFacturaDetalle(int IDActualizar, [FromBody] Factura_Detalle FacturaDetalle)
        {
            return _facturaDetalleService.ActualizarFacturaDetalle(IDActualizar, FacturaDetalle);
        }

        [HttpDelete("{IDAEliminar}")]
        public string EliminarFacturaDetalle(int IDAEliminar)
        {
            return _facturaDetalleService.EliminarFacturaDetalle(IDAEliminar);
        }

        [HttpGet("{IDABuscar}")]
        public Factura_Detalle GetFacturaDetalleByID(int IDABuscar)
        {
            return _facturaDetalleService.GetFacturaDetalleByID(IDABuscar);
        }

    }
}
