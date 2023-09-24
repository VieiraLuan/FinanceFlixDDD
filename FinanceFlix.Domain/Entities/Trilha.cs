using FinanceFlix.API.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Domain.Entities
{
    [Table("TB_TRILHA")]
    public class Trilha
    {
        public Trilha(int id, string nome, string descricao, ICollection<CursoTrilha>? cursosTrilhas)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            CursosTrilhas = cursosTrilhas;
        }

        public Trilha()
        {
        }

        [Column("ID_TRILHA")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]

        public int Id { get; private set; }

        [Column("NOME_TRILHA")]
        [Required]
        [StringLength(80)]
        public string Nome { get; private  set; }

        [Column("DESC_TRILHA")]
        [StringLength(120)]

        public string Descricao { get; private set; }

        public ICollection<CursoTrilha>? CursosTrilhas { get; private set; }
    }
}
