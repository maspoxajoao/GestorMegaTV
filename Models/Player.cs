using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorMegaTv.Models
{
    [Table("player")]
    public class Player
    {
        [Key, Column("PLAYER_ID")]
        public int Id { get; set; }
        [Column("PLAYER_DESCRICAO")]
        public string Descricao { get; set; }

    }
}
