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
        public CursoTrilha(int cursoVideoId, int cursoId, int trilhaId, Curso curso, Trilha trilha)
        {
            CursoVideoId = cursoVideoId;
            CursoId = cursoId;
            TrilhaId = trilhaId;
            Curso = curso;
            Trilha = trilha;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int CursoVideoId { get; private set; }

        public int CursoId { get; private set; }

        public int TrilhaId { get; private set; }


        public Curso Curso { get; private set; }


        public Trilha Trilha { get; private set; }
    }
}
