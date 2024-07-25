using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorMegaTv.Models
{
    [Table("tipoclima")]
    public class TipoClima
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("codigo")]
        public string Codigo { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("icon")]
        public string Icon { get; set; }
    }
}
