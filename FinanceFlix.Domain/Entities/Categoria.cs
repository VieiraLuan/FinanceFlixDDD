using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceFlix.API.Entities
{
    [Table("TB_CATEGORIA")]
    public class Categoria
    {
        [Column("ID_CATEGORIA")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Column("NOME_CATEGORIA")]

        [StringLength(80)]
        public string Nome { get; set; }

        [Column("DESC_CATEGORIA")]

        [StringLength(120)]
        public string Descricao { get; set; }

        public ICollection<Curso>? Cursos { get; set; }


    }
}