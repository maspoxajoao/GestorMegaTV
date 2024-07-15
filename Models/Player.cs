using GestorMegaTv.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorMegaTv.Models
{
    [Table("player")]
    public class Player
    {
        [Key, Column("PLAYER_ID")]
        public int Id { get; set; }
        [Column("PLAYER_DESCRICAO"),PropOptions(Filtravel = true)]
        public string Descricao { get; set; }

    }
}
