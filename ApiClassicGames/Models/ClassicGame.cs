using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ApiClassicGames.Models
{
    [Table("ClassicGames")]
    public class ClassicGame
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
        public string? Categoria { get; set; }
        public string? Plataforma { get; set;}
        public int? Ano { get; set; }
        public string? Descricao { get; set; }
        public string? Foto { get; set; }
        public string? Desenvolvedor { get; set;}
        public string? Publicador { get; set;}

        [Required]
        public string Status { get; set; }

    }
}
