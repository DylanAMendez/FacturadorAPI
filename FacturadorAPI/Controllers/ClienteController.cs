using FacturadorAPI.Modelos;
using FacturadorAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FacturadorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("GetAllClientes")]
        public List<Cliente> GetAllClientes()
        {
            return _clienteService.GetAllClientes();
        }

        [HttpPost("AddCliente")]
        public string AddCliente([FromBody] Cliente cliente)
        {
            return _clienteService.AddCliente(cliente);
        }

        [HttpPut("{IDActualizar}")]
        public string ActualizarCliente([FromBody] Cliente cliente)
        {
            return _clienteService.ActualizarDatosCliente(cliente);
        }

        [HttpDelete("{ClienteIDAEliminar}")]
        public string EliminarCliente(int ClienteIDAEliminar)
        {
            return _clienteService.EliminarCliente(ClienteIDAEliminar);
        }

        [HttpGet("GetClienteByID/{IDABuscar}")]
        public Cliente GetClienteByID(int IDABuscar)
        {
            return _clienteService.GetClienteByID(IDABuscar);
        }

    }
}
