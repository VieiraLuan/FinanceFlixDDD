using FinanceFlix.Domain.Entities;


namespace FinanceFlix.API.Entities
{

    public class Video : Entity
    {
        public Video(Guid id, string nome, string descricao, string url, int duracaoSegundos,
            string? filePath, ICollection<CursoVideo>? cursosVideos)
        {

            Nome = nome;
            Descricao = descricao;
            Url = url;
            DuracaoSegundos = duracaoSegundos;
            FilePath = filePath;
            CursosVideos = cursosVideos;
        }

        public Video(Guid id, string nome, string descricao, string url, int duracaoSegundos,
            string? filePath, Guid cursoid)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Url = url;
            DuracaoSegundos = duracaoSegundos;
            FilePath = filePath;
            ICollection<CursoVideo> cursoVideosList = new List<CursoVideo>();
            var cursoVideoEntity = new CursoVideo(cursoid, id);
            cursoVideosList.Add(cursoVideoEntity);
            CursosVideos = cursoVideosList;

        }

        public Video(string nome, string descricao, string url, int duracaoSegundos,
           string? filePath)
        {

            Nome = nome;
            Descricao = descricao;
            Url = url;
            DuracaoSegundos = duracaoSegundos;
            FilePath = filePath;

        }

        public Video()
        {
        }



        public string Nome { get; private set; } // Título do vídeo


        public string Descricao { get; private set; } // Descrição do vídeo


        public string Url { get; private set; } // URL do vídeo


        public int DuracaoSegundos { get; private set; } // Duração do vídeo em segundos


        public string? FilePath { get; private set; } // Caminho do arquivo de vídeo no servidor

        public ICollection<CursoVideo>? CursosVideos { get; private set; }



    }
}
