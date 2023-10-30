using FinanceFlix.Domain.Entities;


namespace FinanceFlix.API.Entities
{

    public class Video : Entity
    {
        public Video(Guid id, string nome, string descricao, string url, int duracaoSegundos,
             ICollection<CursoVideo>? cursosVideos)
        {

            Nome = nome;
            Descricao = descricao;
            Url = url;
            DuracaoSegundos = duracaoSegundos;
            CursosVideos = cursosVideos;
        }

        public Video(Guid id, string nome, string descricao, string url, int duracaoSegundos, string filePath, Guid cursoId)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Url = url;
            DuracaoSegundos = duracaoSegundos;
            ICollection<CursoVideo> cursoVideosList = new List<CursoVideo>();
            var cursoVideoEntity = new CursoVideo(cursoId, id);
            cursoVideosList.Add(cursoVideoEntity);
            CursosVideos = cursoVideosList;

        }

        public Video(string nome, string descricao, string url, int duracaoSegundos)
        {
            //Add Video
            Nome = nome;
            Descricao = descricao;
            DuracaoSegundos = duracaoSegundos;
            Url = url;

        }

        public Video()
        {
        }



        public string Nome { get; private set; } // Título do vídeo


        public string Descricao { get; private set; } // Descrição do vídeo


        public string Url { get; private set; } // URL do vídeo


        public int DuracaoSegundos { get; private set; } // Duração do vídeo em segundos


        public string? FilePath { get; private set; } // Caminho do arquivo de vídeo no servidor

        public int? Vizualizacoes { get; private set; } // Quantidade de vezes que o vídeo foi visualizado

        public ICollection<CursoVideo>? CursosVideos { get; private set; }



    }
}
