using FacturadorAPI.Modelos;
using FacturadorAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

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
            var lsAllClientes = _clienteService.GetAllClientes();

            Log.Information("GetAllClientes : {@lsAllClientes}", lsAllClientes);

            return lsAllClientes;
        }

        [HttpPost("AddCliente")]
        public string AddCliente([FromBody] Cliente cliente)
        {
            Log.Information("AddCliente : {@cliente}", cliente);
            return _clienteService.AddCliente(cliente);
        }

        [HttpPut("{IDActualizar}")]
        public string ActualizarCliente([FromBody] Cliente cliente)
        {
            Log.Information("ActualizarCliente : {@cliente}", cliente);
            return _clienteService.ActualizarDatosCliente(cliente);
        }

        [HttpDelete("{ClienteIDAEliminar}")]
        public string EliminarCliente(int ClienteIDAEliminar)
        {
            Log.Information("EliminarCliente : {@ClienteIDAEliminar}", ClienteIDAEliminar);
            return _clienteService.EliminarCliente(ClienteIDAEliminar);
        }

        [HttpGet("GetClienteByID/{IDABuscar}")]
        public Cliente GetClienteByID(int IDABuscar)
        {
            Log.Information("GetClienteByID : {@IDABuscar}", IDABuscar);
            return _clienteService.GetClienteByID(IDABuscar);
        }

    }
}
