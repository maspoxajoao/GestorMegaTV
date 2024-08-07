using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorMegaTv.Models
{
    [Table("midiacampanha")]
    public class CampanhaMidia
    {
        [Key,Column("MIDIACAMPANHA_ID")]
        public int Id { get; set; }
        [Column("MIDIACAMPANHA_ID_CAMPANHA")]
        public int? CampanhaId { get; set; }
        [Column("MIDIACAMPANHA_ID_MIDIA")]
        public int? MidiaId { get; set; }
        [Column("MIDIACAMPANHA_POSICAO")]
        public int? Posicao { get; set; }
        [Column("MIDIA_CAMPANHA_DURACAO")]
        public int? Duracao { get; set; }

        [Column("MIDIA_CAMPANHA_DATA_INICIO")]
        public DateTime? DataInicio { get; set; }

        [Column("MIDIA_CAMPANHA_DATA_FIM")]
        public DateTime? DataFim { get; set; }

        public Midia Midia { get; set; }
    }
}
