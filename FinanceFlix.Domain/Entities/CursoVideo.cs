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
        public CursoVideo(int cursoVideoId, int cursoId, int videoId, Curso curso, Video video)
        {
            CursoVideoId = cursoVideoId;
            CursoId = cursoId;
            VideoId = videoId;
            Curso = curso;
            Video = video;
        }

        public CursoVideo()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int CursoVideoId { get; private set; }

        public int CursoId { get; private set; }

        public int VideoId { get; private set; }


        public Curso Curso { get; private set; }

        public Video Video { get; private set; }
    }
}
