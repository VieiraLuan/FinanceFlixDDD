using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceFlix.API.Entities
{
    [Table("TB_CURSO")]
    public class Curso
    {
        [Column("ID_CURSO")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column("NOME_CURSO")]
        [Required]
        [StringLength(80)]
        public string Nome { get; set; }

        [Column("DESC_CURSO")]
        [Required]
        [StringLength(120)]
        public string Descricao { get; set; }

        [Column("IMG_CURSO")]
        public byte[]? ImagemUrl { get; set; }

        public Categoria? Categoria { get; set; }

        public ICollection<Video>? Videos { get; set; }  




    }
}
