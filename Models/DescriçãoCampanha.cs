using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorMegaTv.Models
{
    [Table("descricaocampanha")]
    public class Descricaocampanha
    {
        [Key, Column("DESCRICAOCAMPANHA_CAMPANHA_ID")]
        public int CampanhaId { get; set; }

        [Column("DESCRICAOCAMPANHA_CAMPANHA_DESCRICAO")]
        public string Descricao { get; set; }
    }
}
