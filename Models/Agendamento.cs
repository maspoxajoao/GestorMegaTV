using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorMegaTv.Models
{
    [Table("agendamento")]
    public class Agendamento
    {
        [Key, Column("AGENDAMENTO_ID")]
        public int Id { get; set; }

        [Column("AGENDAMENTO_PLAYER_ID")]
        public int PlayerId { get; set; }

        [Column("AGENDAMENTO_CAMPANHA_ID")]
        public int CampanhaId { get; set; }

        [Column("AGENDAMENTO_DATA_INICIO")]
        public DateTime? DataInicio { get; set; }

        [Column("AGENDAMENTO_DATA_FIM")]
        public DateTime? DataFim { get; set; }

        [Column("AGENDAMENTO_POSICAO")]
        public int Posicao { get; set; }

        [Column("AGENDAMENTO_TELA")]
        public char Tela { get; set; }
    }
}
