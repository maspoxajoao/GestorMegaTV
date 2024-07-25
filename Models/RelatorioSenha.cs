using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace GestorMegaTv.Models
{
    [Table("relatoriosenha")]
    public class RelatorioSenha
    {
        [Key, Column(Order = 0)]
        public int IdPlayer { get; set; }

        [Key, Column(Order = 1)]
        public int Numero { get; set; }

        [Key, Column(Order = 2)]
        public DateTime DataChamou { get; set; }

        [Column("fila")]
        public string Fila { get; set; }

        [Column("prefixo")]
        public string Prefixo { get; set; }

        [Column("guiche")]
        public string Guiche { get; set; }

        [Column("data")]
        public DateTime? Data { get; set; }

        [Column("usuario")]
        public string Usuario { get; set; }
    }
}
