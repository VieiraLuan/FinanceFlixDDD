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
    [Table("TB_CURSO_VIDEO")]
    public class CursoVideo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int CursoVideoId { get; set; }

        public int CursoId { get; set; }

        public int VideoId { get; set; }


        public Curso Curso { get; set; }

        public Video Video { get; set; }
    }
}
