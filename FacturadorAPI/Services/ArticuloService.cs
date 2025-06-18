using FacturadorAPI.Modelos;
using Serilog;

namespace FacturadorAPI.Services
{
    public class ArticuloService
    {

        private readonly AppDbContext _context;

        public ArticuloService(AppDbContext context)
        {
            _context = context;
        }

        public List<Articulo> GetAllArticulos()
        {
            try
            {
                return _context.articulo.ToList();
            }
            catch (Exception ex)
            {
                Log.Error("GetAllArticulos : {@ex}", ex.Message);
                return new List<Articulo>();
            }
        }

        public Articulo GetArticuloByID(int IDABuscar)
        {
            try
            {
                var articuloABuscar = _context.articulo.FirstOrDefault(x => x.Articulo_ID.Equals(IDABuscar));

                if(articuloABuscar is null) return new Articulo();

                return articuloABuscar;

            }
            catch (Exception ex)
            {
                Log.Error("GetArticuloByID : {@ex}", ex.Message);
                return new Articulo();
            }
        }

        public string AddArticulo(Articulo articulo)
        {
            try
            {
                if (articulo is null) return "Error articulo null";

                if (articulo.ART_ID.Length > 50) return "ART_ID no puede contener mas de 50 caracteres";

                _context.articulo.Add(articulo);
                _context.SaveChanges();

                return "Articulo agregado con ID: " + articulo.ART_ID;

            }
            catch (Exception ex)
            {
                Log.Error("AddArticulo : {@ex}", ex.Message);
                return "Error al agregar articulo" + ex.Message;
            }
        }

        public string ActualizarArticulo(int IDActualizar, Articulo articuloActualizar)
        {
            try
            {

                if (articuloActualizar is null) return "Error articulo null";

                var articuloABuscar = _context.articulo.FirstOrDefault(x => x.Articulo_ID.Equals(IDActualizar));

                if (articuloABuscar is null) return "No se encontro articulo con ID : " + IDActualizar;

                if (articuloActualizar.ART_ID.Length > 50) return "ART_ID no puede contener mas de 50 caracteres";

                articuloABuscar.Cant = articuloActualizar.Cant;
                articuloABuscar.ART_ID = articuloActualizar.ART_ID;
                articuloABuscar.Moto = articuloActualizar.Moto;
                articuloABuscar.Precio = articuloActualizar.Precio;
                articuloABuscar.Cli_ID = articuloActualizar.Cli_ID;
                articuloABuscar.Nombre = articuloActualizar.Nombre;

                _context.SaveChanges();

                return "Articulo actualizado con ID: " + articuloActualizar.Articulo_ID;

            }
            catch (Exception ex)
            {
                Log.Error("ActualizarArticulo : {@ex}", ex.Message);
                return "Error al actualizar articulo con ID : " + articuloActualizar.ART_ID;
            }
        }

        public string EliminarArticulo(int IDAEliminar)
        {
            try
            {
                var articuloAEliminar = _context.articulo.FirstOrDefault(x => x.Articulo_ID.Equals(IDAEliminar));

                if (articuloAEliminar is null) return "No se encontro articulo para eliminar con ID : " + IDAEliminar;

                _context.articulo.Remove(articuloAEliminar);
                _context.SaveChanges();

                return "Articulo eliminado con ID : " + IDAEliminar;

            }
            catch (Exception ex)
            {
                Log.Error("EliminarArticulo : {@ex}", ex.Message);
                return "Error al eliminar articulo con ID : " + IDAEliminar + " " + ex.Message;
            }
        }
    }
}
