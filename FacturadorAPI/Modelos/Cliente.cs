using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacturadorAPI.Modelos
{
    public class Cliente
    {
        [Key]
        public int Cli_ID { get; set; }

        [Column("Razon Social")]
        public string RazonSocial { get; set; }

        public string CUIT { get; set; }
        public string Direccion { get; set; }
        public bool Deshabilitado { get; set; }

    }
}
