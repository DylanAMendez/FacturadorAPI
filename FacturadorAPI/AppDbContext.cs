using FacturadorAPI.Modelos;
using Microsoft.EntityFrameworkCore;

namespace FacturadorAPI
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Cliente> cliente { get; set; }
        public DbSet<Factura_Cabecera> factura_Cabecera { get; set; }
        public DbSet<Factura_Detalle> factura_Detalle { get; set; }
        public DbSet<Articulo> articulo { get; set; }
        public DbSet<FacturaCabeceraYDetalle> facturaCabeceraYDetalle { get; set; }

    }
}
