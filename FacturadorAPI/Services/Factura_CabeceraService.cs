using FacturadorAPI.Modelos;

namespace FacturadorAPI.Services
{
    public class Factura_CabeceraService
    {
        private readonly AppDbContext _context;

        public Factura_CabeceraService(AppDbContext context)
        {
            _context = context;
        }

        public List<Factura_Cabecera> GetAllFacturaCabecera()
        {
            try
            {
                return _context.factura_Cabecera.ToList();
            }
            catch (Exception ex)
            {
                return new List<Factura_Cabecera>();
            }
        }

        public string AddFacturaCabecera(Factura_Cabecera facturaCabecera)
        {
            try
            {
                if (facturaCabecera is null) return "Factura Cabecera null";

                if (facturaCabecera.Cli_ID.Length > 50) return "Cli_ID no puede contener mas de 50 caracteres";
                if(facturaCabecera.Estado.Length > 50) return "Estado no puede contener mas de 50 caracteres";

                _context.factura_Cabecera.Add(facturaCabecera);
                _context.SaveChanges();

                return "Factura cabecera agregada con ID: " + facturaCabecera.FC_ID;
            }
            catch (Exception ex)
            {
                return "Error al agregar factura cabecera " + ex.Message;
                throw;
            }
        }

        public string ActualizarFacturaCabecera(int IDActualizar ,Factura_Cabecera FacturaCabeceraActualizar)
        {
            try
            {
                var facturaAactualizar = _context.factura_Cabecera.FirstOrDefault(x => x.FC_ID.Equals(IDActualizar));

                if (facturaAactualizar is null) return "No se encontro una factura cabecera con ID : " + IDActualizar;

                facturaAactualizar.FechaAlta = FacturaCabeceraActualizar.FechaAlta;
                facturaAactualizar.Cli_ID = FacturaCabeceraActualizar.Cli_ID;
                facturaAactualizar.Estado = FacturaCabeceraActualizar.Estado;

                _context.SaveChanges();

                return "Datos actualizados de factura cabecera : " + FacturaCabeceraActualizar.FC_ID;
            }
            catch (Exception ex)
            {
                return "Error al actualizar factura cabecera : " + ex.Message;
            }
        }

        public string EliminarFacturaCabecera(int IDAEliminarFacturaCabecera)
        {
            try
            {
                var facturaAEliminar = _context.factura_Cabecera.FirstOrDefault(x => x.FC_ID.Equals(IDAEliminarFacturaCabecera));

                if (facturaAEliminar is null) return "No se encontro una factura cabecera con ID : " + IDAEliminarFacturaCabecera;

                _context.Remove(facturaAEliminar);
                _context.SaveChanges();

                return "Factura cabecera con ID : " + IDAEliminarFacturaCabecera + " eliminado";
            }
            catch (Exception ex)
            {
                return "Error al eliminar factura cabecera : " + ex.Message;
            }
        }

        public Factura_Cabecera GetFacturaCabeceraByID(int IDABuscar)
        {
            try
            {
                var facturaCabeceraABuscar = _context.factura_Cabecera.FirstOrDefault(x => x.FC_ID.Equals(IDABuscar));

                if(facturaCabeceraABuscar is null) return new Factura_Cabecera();

                return facturaCabeceraABuscar;

            }
            catch (Exception ex)
            {
                return new Factura_Cabecera();
            }
        }

    }
}
