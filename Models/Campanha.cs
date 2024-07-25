using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorMegaTv.Models
{
    [Table("campanha")]
    public class Campanha
    {
        [Key, Column("CAMPANHA_ID")]
        public int Id { get; set; }
        [Column("CAMPANHA_DESCRICAO")]
        public string Descricao { get; set; }

        public List<CampanhaMidia> CampanhaMidias { get; set; }
    }
}
