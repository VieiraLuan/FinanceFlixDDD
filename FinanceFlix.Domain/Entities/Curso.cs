using FinanceFlix.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceFlix.API.Entities
{
    //Produto
    [Table("TB_CURSO")]
    public class Curso
    {
        [Column("ID_CURSO")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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

       
        public int CategoriaId { get; set; }

     
        public Categoria? Categoria { get; set; }

        public ICollection<CursoVideo>? CursosVideos { get; set; }

        public ICollection<CursoTrilha>? CursosTrilhas{ get; set; }




    }
}
