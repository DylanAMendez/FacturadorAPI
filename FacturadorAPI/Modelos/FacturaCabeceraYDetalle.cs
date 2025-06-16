using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacturadorAPI.Modelos
{
    public class FacturaCabeceraYDetalle
    {
        [Key]
        public int FC_ID { get; set; }
        [Column("Fecha Alta")]
        public DateOnly FechaAlta { get; set; }
        public string Cli_ID { get; set; }
        public string Estado { get; set; }
        public string ART_ID { get; set; }
        public int Fact_ID { get; set; }
        public decimal Cant { get; set; }
        public decimal Moto { get; set; }
    }
}
