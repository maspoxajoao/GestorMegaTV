using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorMegaTv.Models
{
    [Table("pagamentos")]
    public class Pagamento
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("dataCriacao")]
        public DateTime? DataCriacao { get; set; }

        [Column("dataAtualizacao")]
        public DateTime? DataAtualizacao { get; set; }

        [Column("dataAprovacao")]
        public DateTime? DataAprovacao { get; set; }

        [Column("usuarioId")]
        public int? UsuarioId { get; set; }

        [Column("valor")]
        public decimal? Valor { get; set; }

        [Required]
        [Column("status")]
        public string Status { get; set; }

        [Column("codigo")]
        public string Codigo { get; set; }

        [Column("externalId")]
        public string ExternalId { get; set; }

        [Column("categoriaId")]
        public int? CategoriaId { get; set; }
    }
}
