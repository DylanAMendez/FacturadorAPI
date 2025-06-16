using FacturadorAPI.Modelos;
using FacturadorAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FacturadorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private readonly ArticuloService _articuloService;

        public ArticuloController(ArticuloService articuloService)
        {
            _articuloService = articuloService;
        }

        [HttpGet]
        public List<Articulo> GetAllArticulos()
        {
            var lsArticulos = _articuloService.GetAllArticulos();

            Log.Information("GetAllArticulos : {@lsArticulos}", lsArticulos);

            return lsArticulos;
        }

        [HttpGet("{IDABuscar}")]
        public Articulo GetArticuloByID(int IDABuscar)
        {
            var articulo = _articuloService.GetArticuloByID(IDABuscar);

            Log.Information("GetArticuloByID : {@articulo}", articulo);

            return articulo;
        }

        [HttpPost]
        public string AddArticulo([FromBody] Articulo articuloAgregar)
        {
            Log.Information("ActualizarArticulo : {@articuloAgregar}", articuloAgregar);
            return _articuloService.AddArticulo(articuloAgregar);
        }

        [HttpPut("{IDActualizar}")]
        public string ActualizarArticulo(int IDActualizar, [FromBody] Articulo articuloActualizar)
        {
            Log.Information("ActualizarArticulo : {@articuloActualizar}", articuloActualizar);
            return _articuloService.ActualizarArticulo(IDActualizar, articuloActualizar);
        }

        [HttpDelete("{IDAEliminar}")]
        public string Delete(int IDAEliminar)
        {
            Log.Information("GetArticuloByID : {@IDAEliminar}", IDAEliminar);
            return _articuloService.EliminarArticulo(IDAEliminar);
        }
    }
}
