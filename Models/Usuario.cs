using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorMegaTv.Models
{
    [Table("usuario")]
    public class Usuario
    {
        [Key]
        [Column("USUARIO_ID")]
        public int Id { get; set; }

        [Column("USUARIO_USERNAME")]
        public string Username { get; set; }

        [Column("USUARIO_SENHA")]
        public string Senha { get; set; }

        [Column("USUARIO_NIVEL_ADMIN")]
        public int NivelAdmin { get; set; }

        [Column("USUARIO_EMAIL")]
        public string Email { get; set; }

        [Column("USUARIO_NOME")]
        public string Nome { get; set; }

        [Column("USUARIO_ATIVO")]
        public bool Ativo { get; set; }

        [Column("USUARIO_MAXIMO_PLAYERS")]
        public int MaximoPlayers { get; set; }

        [Column("USUARIO_RSS")]
        public bool Rss { get; set; }

        [Column("USUARIO_CAIXA_LIVRE")]
        public bool CaixaLivre { get; set; }

        [Column("USUARIO_SPOTIFY")]
        public bool Spotify { get; set; }

        [Column("USUARIO_CODIGO_VALIDACAO")]
        public string CodigoValidacao { get; set; }

        [Column("USUARIO_CONFIRMADO")]
        public bool Confirmado { get; set; }

        [Column("USUARIO_TELEFONE")]
        public string Telefone { get; set; }
    }
}
