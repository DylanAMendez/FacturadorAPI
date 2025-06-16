using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacturadorAPI.Modelos
{
    public class Factura_Cabecera
    {
        [Key]
        public int FC_ID { get; set; }

        [Column("Fecha Alta")]
        public DateOnly FechaAlta { get; set; }

        public string Cli_ID { get; set; }
        public string Estado { get; set; }

    }
}
