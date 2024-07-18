using GestorMegaTv.Utils;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorMegaTv.Models
{
    [Table("player")]
    public class Player
    {
        [Key, Column("PLAYER_ID")]
        public int Id { get; set; }

        [Column("PLAYER_DESCRICAO"), PropOptions(Filtravel = true)]
        public string Descricao { get; set; }

        [Column("PLAYER_ULTIMACONEXAO"), PropOptions(Filtravel = true)]
        public DateTime? UltimaConexao { get; set; }

        [Column("PLAYER_DESATIVAR_AUDIO")]
        public bool? DesativarAudio { get; set; }

        [Column("PLAYER_RELOGIO")]
        public bool? ExibirRelogio { get; set; }

        [Column("PLAYER_ORIENTACAO")]
        public string Orientacao { get; set; }

        [Column("PLAYER_CAIXA_LIVRE")]
        public bool? CaixaLivre { get; set; }

        [Column("PLAYER_SENHAS")]
        public bool? Senhas { get; set; }

    }
}
