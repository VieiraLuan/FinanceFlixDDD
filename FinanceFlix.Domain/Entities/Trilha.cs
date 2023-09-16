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
        [Column("ID_TRILHA")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        
        public Guid Id { get; set; }

        [Column("NOME_TRILHA")]
        [Required]
        [StringLength(80)]
        public string Nome { get; set; }

        [Column("DESC_TRILHA")]
        [StringLength(120)]

        public string Descricao { get; set; }

        public ICollection<Curso> Cursos { get; set; }
    }
}
