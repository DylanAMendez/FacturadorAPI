using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacturadorAPI.Modelos
{
    public class Factura_Detalle
    {
        public int Fact_ID { get; set; }
     
        [Key]
        public int FC_DTL_ID {  get; set; }

        [Column("Fecha Alta")]
        public DateOnly FechaAlta { get; set; }

        public string ART_ID { get; set; }
        public decimal Cant { get; set; }
        public decimal Precio { get; set; }
        public decimal Moto { get; set; }
    }
}
