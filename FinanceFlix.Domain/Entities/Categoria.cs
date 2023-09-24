using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceFlix.API.Entities
{
    [Table("TB_CATEGORIA")]
    public class Categoria
    {
        public Categoria()
        {
        }

        public Categoria(string nome, string descricao)
        {
            
            Nome = nome;
            Descricao = descricao;

        }

        public Categoria(int id, string nome, string descricao, ICollection<Curso>? cursos)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Cursos = cursos;
        }

        [Column("ID_CATEGORIA")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; private set; }

        [Column("NOME_CATEGORIA")]

        [StringLength(80)]
        public string Nome { get; private set; }

        [Column("DESC_CATEGORIA")]

        [StringLength(120)]
        public string Descricao { get; private set; }

        public ICollection<Curso>? Cursos { get; private set; }


    }
}