using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorMegaTv.Models
{
    [Table("descricaomidia")]
    public class Descricaomidia
    {
        [Key, Column("DESCRICAOMIDIA_MIDIA_ID")]
        public int MidiaId { get; set; }

        [Column("DESCRICAOMIDIA_MIDIA_DESCRICAO")]
        public string Descricao { get; set; }
    }
}
