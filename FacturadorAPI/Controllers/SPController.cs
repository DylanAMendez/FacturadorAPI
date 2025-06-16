using FacturadorAPI.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FacturadorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SPController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SPController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("SP1/{FechaDesde}/{FechaHasta}/{IDCliente}")]
        public string GetSP()
        {
            var pathLogs = @"C:/TCP_LOGS";
            var hoy = DateTime.Now;
            var registrosDevueltos = 0;

            try
            {
                var FechaDesde = DateOnly.Parse((string)RouteData.Values["FechaDesde"]);
                var FechaHasta = DateOnly.Parse((string)RouteData.Values["FechaHasta"]);
                var IDCliente = int.Parse((string)RouteData.Values["IDCliente"]);

                var fechaDesde = new SqlParameter("@FechaDesde", FechaDesde);
                var fechaHasta = new SqlParameter("@FechaHasta", FechaHasta);
                var idCliente = new SqlParameter("@IDCliente", IDCliente);

                var resultado = _context.factura_Cabecera.FromSqlRaw("EXEC FacturasCabeceraYDetalle @FechaDesde, @FechaHasta, @IDCliente", fechaDesde, fechaHasta, idCliente).ToList();

                registrosDevueltos = resultado.Count;

                return "Query OK";
            }
            catch (Exception ex)
            {
                return "Error";
            }
            finally
            {
                if (!Directory.Exists(pathLogs))
                {
                    Directory.CreateDirectory(pathLogs);
                }

                var archivoLog = Path.Combine(pathLogs, "log.txt");

                System.IO.File.AppendAllText(archivoLog, $"=== SP1 ejecutado , fecha : {hoy} , registros devueltos : {registrosDevueltos} ===\n ");
            }
        }

        [HttpGet("SP2/{FechaDesde}/{FechaHasta}/{IDCliente}")]
        public List<FacturaCabeceraYDetalle> GetSPx()
        {
            var pathLogs = @"C:/TCP_LOGS";
            var hoy = DateTime.Now;
            var registrosDevueltos = 0;

            try
            {
                var FechaDesde = DateOnly.Parse((string)RouteData.Values["FechaDesde"]);
                var FechaHasta = DateOnly.Parse((string)RouteData.Values["FechaHasta"]);
                var IDCliente = int.Parse((string)RouteData.Values["IDCliente"]);

                var fechaDesde = new SqlParameter("@FechaDesde", FechaDesde);
                var fechaHasta = new SqlParameter("@FechaHasta", FechaHasta);
                var idCliente = new SqlParameter("@IDCliente", IDCliente);

                var resultado = _context.facturaCabeceraYDetalle.FromSqlRaw("EXEC FacturasCabeceraYDetalle @FechaDesde, @FechaHasta, @IDCliente", fechaDesde, fechaHasta, idCliente).ToList();

                registrosDevueltos = resultado.Count;

                return resultado;
            }
            catch (Exception ex)
            {
                return new List<FacturaCabeceraYDetalle>();
            }
            finally
            {
                if (!Directory.Exists(pathLogs))
                {
                    Directory.CreateDirectory(pathLogs);
                }

                var archivoLog = Path.Combine(pathLogs, "log.txt");

                System.IO.File.AppendAllText(archivoLog, $"=== SP2 ejecutado , fecha : {hoy} , registros devueltos : {registrosDevueltos} ===\n");
            }
        }





    }
}
