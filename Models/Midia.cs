using GestorMegaTv.Utils;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorMegaTv.Models
{
    [Table("midia")]
    public class Midia
    {
        [Key, Column("MIDIA_ID")]
        public int Id { get; set; }

        [Column("MIDIA_ENDERECO")]
        public string Endereco { get; set; }

        [Column("MIDIA_TIPO"),]
        public string Tipo { get; set; }

        [Column("MIDIA_DURACAO")]
        public int Duracao { get; set; }

        [Column("MIDIA_ESTADO")]
        public string Estado { get; set; }

        [Column("MIDIA_DATA"), PropOptions(Filtravel = true)]
        public DateTime? Data { get; set; }

        [Column("MIDIA_EXCLUIDA"),]
        public bool Excluida { get; set; }

    }
}
