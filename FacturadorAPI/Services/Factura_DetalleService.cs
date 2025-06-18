using FacturadorAPI.Modelos;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace FacturadorAPI.Services
{
    public class Factura_DetalleService
    {
        private readonly AppDbContext _context;

        public Factura_DetalleService(AppDbContext context)
        {
            _context = context;
        }

        public List<Factura_Detalle> GetAllFacturaDetalle()
        {
            try
            {
               return _context.factura_Detalle.ToList();
            }
            catch (Exception ex)
            {
                Log.Error("GetAllFacturaDetalle : {@ex}", ex.Message);
                return new List<Factura_Detalle>();
            }
        }

        public string AddFacturaDetalle(Factura_Detalle facturaDetalle)
        {
            try
            {
                if (facturaDetalle is null) return "Error facturaDetalle null";

                if (facturaDetalle.ART_ID.Length > 50) return "";

                var ultimaFactura = _context.factura_Detalle.OrderBy(x => x.FC_DTL_ID).LastOrDefault();

                if (ultimaFactura != null)
                {
                    facturaDetalle.FC_DTL_ID = ultimaFactura.FC_DTL_ID + 1;
                }
                else
                {
                    facturaDetalle.FC_DTL_ID = 1;
                    facturaDetalle.Fact_ID = 1;
                }

                _context.factura_Detalle.Add(facturaDetalle);
                _context.SaveChanges();

                return "Factura detalle agregado con ID : " + facturaDetalle.FC_DTL_ID;

            }
            catch (Exception ex)
            {
                Log.Error("AddFacturaDetalle : {@ex}", ex.Message);
                return "Error al agregar factura detalle" + ex.Message;
            }
        }

        public string ActualizarFacturaDetalle(int IDActualizar, Factura_Detalle facturaDetalle)
        {
            try
            {
                var facturaActualizar = _context.factura_Detalle.FirstOrDefault(x => x.FC_DTL_ID.Equals(IDActualizar));

                if (facturaActualizar is null) return "Error no se encontro factura a actualizar con ID : " + IDActualizar;

                facturaActualizar.FechaAlta = facturaDetalle.FechaAlta;
                facturaActualizar.Cant = facturaDetalle.Cant;
                facturaActualizar.ART_ID = facturaDetalle.ART_ID;
                facturaActualizar.Precio = facturaDetalle.Precio;
                facturaActualizar.Moto = facturaDetalle.Moto;

                _context.SaveChanges();

                return "Factura detalle actualizado con ID : " + IDActualizar;
            }
            catch (Exception ex)
            {
                Log.Error("ActualizarFacturaDetalle : {@ex}", ex.Message);
                return "Error al actualizar : " + ex.Message;
            }

        }

        public string EliminarFacturaDetalle(int IDAEliminar)
        {
            try
            {
                var facturaAEliminar = _context.factura_Detalle.FirstOrDefault(x => x.FC_DTL_ID.Equals(IDAEliminar));

                if (facturaAEliminar is null) return "No se encontro factura detalle con ID : " + IDAEliminar;

                _context.factura_Detalle.Remove(facturaAEliminar);
                _context.SaveChanges();

                return "Factura detalle con ID : " + IDAEliminar + " eliminado";
            }
            catch (Exception ex)
            {
                Log.Error("EliminarFacturaDetalle : {@ex}", ex.Message);
                return "Error al eliminar ID : " + IDAEliminar;
            }
        }

        public Factura_Detalle GetFacturaDetalleByID(int IDABuscar)
        {
            try
            {
                var facturaDetalleABuscar = _context.factura_Detalle.FirstOrDefault(x => x.FC_DTL_ID.Equals(IDABuscar));

                if(facturaDetalleABuscar is null) return new Factura_Detalle();

                return facturaDetalleABuscar;

            }
            catch (Exception ex)
            {
                Log.Error("GetFacturaDetalleByID : {@ex}", ex.Message);
                return new Factura_Detalle();
            }
        }

    }
}
