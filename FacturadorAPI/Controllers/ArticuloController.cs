using FacturadorAPI.Modelos;
using FacturadorAPI.Services;
using Microsoft.AspNetCore.Mvc;

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
            return _articuloService.GetAllArticulos();
        }

        [HttpGet("{IDABuscar}")]
        public Articulo GetArticuloByID(int IDABuscar)
        {
            return _articuloService.GetArticuloByID(IDABuscar);
        }

        [HttpPost]
        public string AddArticulo([FromBody] Articulo articuloAgregar)
        {
            return _articuloService.AddArticulo(articuloAgregar);
        }

        [HttpPut("{IDActualizar}")]
        public string ActualizarArticulo(int IDActualizar, [FromBody] Articulo articuloActualizar)
        {
            return _articuloService.ActualizarArticulo(IDActualizar, articuloActualizar);
        }

        [HttpDelete("{IDAEliminar}")]
        public string Delete(int IDAEliminar)
        {
            return _articuloService.EliminarArticulo(IDAEliminar);
        }
    }
}
