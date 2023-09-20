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
    [Table("TB_CURSO_TRILHA")]
    public class CursoTrilha
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int CursoVideoId { get; set; }

        public int CursoId { get; set; }

        public int TrilhaId { get; set; }


        public Curso Curso { get; set; }


        public Trilha Trilha { get; set; }
    }
}
