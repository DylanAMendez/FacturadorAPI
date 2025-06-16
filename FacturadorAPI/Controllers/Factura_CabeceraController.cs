using FacturadorAPI.Modelos;
using FacturadorAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FacturadorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Factura_CabeceraController : ControllerBase
    {
        private readonly Factura_CabeceraService _facturaCabeceraService;

        public Factura_CabeceraController(Factura_CabeceraService factura_CabeceraService)
        {
            _facturaCabeceraService = factura_CabeceraService;
        }

        [HttpGet]
        public List<Factura_Cabecera> GetAllFactura_Cabecera()
        {
            return _facturaCabeceraService.GetAllFacturaCabecera();
        }

        [HttpPost]
        public string Post([FromBody] Factura_Cabecera factura_Cabecera)
        {
            return _facturaCabeceraService.AddFacturaCabecera(factura_Cabecera);
        }

        [HttpPut("{IDActualizar}")]
        public string ActualizarFacturaCabecera(int IDActualizar, [FromBody] Factura_Cabecera factura_Cabecera)
        {
            return _facturaCabeceraService.ActualizarFacturaCabecera(IDActualizar, factura_Cabecera);
        }

        [HttpDelete("{IDAEliminar}")]
        public string Delete(int IDAEliminar)
        {
            return _facturaCabeceraService.EliminarFacturaCabecera(IDAEliminar);
        }

        [HttpGet("{IDABuscar}")]
        public Factura_Cabecera GetFacturaCabeceraByID(int IDABuscar)
        {
            return _facturaCabeceraService.GetFacturaCabeceraByID(IDABuscar);
        }

    }
}
