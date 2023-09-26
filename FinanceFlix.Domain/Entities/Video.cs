using FinanceFlix.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceFlix.API.Entities
{
    [Table("TB_VIDEO")]
    public class Video
    {
        public Video(int id, string nome, string descricao, string url, int duracaoSegundos,
            string? filePath, ICollection<CursoVideo>? cursosVideos)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Url = url;
            DuracaoSegundos = duracaoSegundos;
            FilePath = filePath;
            CursosVideos = cursosVideos;
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

        [Column("ID_VIDEO")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; } // Identificador único do vídeo
        [Column("NOME_VIDEO")]
        [Required]
        [StringLength(80)]
        public string Nome { get; private set; } // Título do vídeo

        [Column("DESC_VIDEO")]
        [StringLength(120)]
        public string Descricao { get; private set; } // Descrição do vídeo

        [Column("URL_VIDEO")]
        [StringLength(200)]
        public string Url { get; private set; } // URL do vídeo

        [Column("DURACAO_VIDEO")]
        [Required]

        public int DuracaoSegundos { get; private set; } // Duração do vídeo em segundos

        [Column("PATH_VIDEO")]
        [StringLength(200)]
        public string? FilePath { get; private set; } // Caminho do arquivo de vídeo no servidor

        public ICollection<CursoVideo>? CursosVideos { get; private set; }



    }
}
