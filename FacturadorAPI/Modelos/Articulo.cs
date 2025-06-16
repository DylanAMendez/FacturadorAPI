using System.ComponentModel.DataAnnotations;

namespace FacturadorAPI.Modelos
{
    public class Articulo
    {
        [Key]
        public int Articulo_ID { get; set; }

        public string ART_ID { get; set; }
        public decimal Cant {  get; set; }
        public decimal Precio {  get; set; }
        public decimal Moto {  get; set; }
        public int? Cli_ID { get; set; } = 0;
        public string? Nombre { get; set; } = "";

    }
}
