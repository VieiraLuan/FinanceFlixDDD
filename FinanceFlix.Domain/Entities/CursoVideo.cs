using FinanceFlix.API.Entities;


namespace FinanceFlix.Domain.Entities
{
    
    public class CursoVideo:Entity
    {
        public CursoVideo(Guid cursoVideoId, Guid cursoId, Guid videoId, Curso curso, Video video)
        {
            
            CursoId = cursoId;
            VideoId = videoId;
            Curso = curso;
            Video = video;
        }

        public CursoVideo(Guid cursoId, Guid videoId)
        {
            CursoId = cursoId;
            VideoId = videoId;
        }

        public CursoVideo()
        {
        }
        
        public Guid CursoId { get; private set; }

        public Guid VideoId { get; private set; }


        public Curso Curso { get; private set; }

        public Video Video { get; private set; }
    }
}
