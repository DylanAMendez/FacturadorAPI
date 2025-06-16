using FacturadorAPI.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace FacturadorAPI.Services
{
    public class ClienteService
    {
        private readonly AppDbContext _context;

        public ClienteService(AppDbContext context)
        {
            _context = context;
        }

        public List<Cliente> GetAllClientes()
        {
            try
            {
                return _context.cliente.ToList();
            }
            catch (Exception ex)
            {
                return new List<Cliente>();
            }
        }

        public string AddCliente(Cliente cliente)
        {
            try
            {
                if (cliente == null) return "Cliente null";

                if (cliente.CUIT.Length > 50) return "CUIT no puede contener mas de 50 caracteres";
                if (cliente.Direccion.Length > 255) return "Dirección no puede contener mas de 255 caracteres";
                if (cliente.RazonSocial.Length > 255) return "Razon Social no puede contener mas de 255 caracteres";

                _context.cliente.Add(cliente);
                _context.SaveChanges();

                return "Cliente agregado con ID: " + cliente.Cli_ID;
            }
            catch (Exception ex)
            {
                return "Error al agregar cliente: " + ex.Message;
            }
        }

        public string ActualizarDatosCliente(Cliente clienteActualizar)
        {
            try
            {
                var clienteExistente = _context.cliente.FirstOrDefault(x => x.Cli_ID == clienteActualizar.Cli_ID);

                if (clienteExistente == null) return "No se encontro ningun cliente con ID: " + clienteActualizar.Cli_ID;

                clienteExistente.RazonSocial = clienteActualizar.RazonSocial;
                clienteExistente.Deshabilitado = clienteActualizar.Deshabilitado;
                clienteExistente.Direccion = clienteActualizar.Direccion;
                clienteExistente.CUIT = clienteActualizar.CUIT;

                _context.SaveChanges();

                return "Datos actualizados del cliente : " + clienteExistente.Cli_ID;
            }
            catch (Exception ex)
            {
                return "Error al actualizar cliente : " + ex.Message;
            }
        }

        public string EliminarCliente(int ClienteIDAEliminar)
        {
            try
            {
                var clienteAEliminar = _context.cliente.FirstOrDefault(x => x.Cli_ID.Equals(ClienteIDAEliminar));

                if (clienteAEliminar is null) return "No se encontro cliente con ID : " + ClienteIDAEliminar;

                _context.Remove(clienteAEliminar);
                _context.SaveChanges();

                return "Cliente con ID : " + ClienteIDAEliminar + " eliminado";
            }
            catch (Exception ex)
            {
                return "Error al eliminar cliente : " + ex.Message;
            }
        }

        public Cliente GetClienteByID(int IDAbuscar)
        {
            try
            {
                var clienteABuscar = _context.cliente.FirstOrDefault(x => x.Cli_ID.Equals(IDAbuscar));

                if (clienteABuscar is null) return new Cliente();

                return clienteABuscar;
            }
            catch (Exception ex)
            {
                return new Cliente();
            }
        }

    }
}
