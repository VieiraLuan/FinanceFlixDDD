using FinanceFlix.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceFlix.API.Entities
{
    //Produto
    [Table("TB_CURSO")]
    public class Curso
    {
        public Curso(int id, string nome, string descricao, byte[]? imagemUrl, int categoriaId, Categoria? categoria,
            ICollection<CursoVideo>? cursosVideos, ICollection<CursoTrilha>? cursosTrilhas)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            ImagemUrl = imagemUrl;
            CategoriaId = categoriaId;
            Categoria = categoria;
            CursosVideos = cursosVideos;
            CursosTrilhas = cursosTrilhas;
        }

        public Curso()
        {
        }

        [Column("ID_CURSO")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [Column("NOME_CURSO")]
        [Required]
        [StringLength(80)]
        public string Nome { get; private set; }

        [Column("DESC_CURSO")]
        [Required]
        [StringLength(120)]
        public string Descricao { get; private set; }

        [Column("IMG_CURSO")]
        public byte[]? ImagemUrl { get; private set; }


        public int CategoriaId { get; private set; }


        public Categoria? Categoria { get; private set; }

        public ICollection<CursoVideo>? CursosVideos { get; private set; }

        public ICollection<CursoTrilha>? CursosTrilhas { get; private set; }




    }
}
