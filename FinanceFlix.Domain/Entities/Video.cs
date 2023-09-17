using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceFlix.API.Entities
{
    [Table("TB_VIDEO")]
    public class Video
    {
        [Column("ID_VIDEO")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Guid { get; set; } // Identificador único do vídeo
        [Column("NOME_VIDEO")]
        [Required]
        [StringLength(80)]
        public string Nome { get; set; } // Título do vídeo

        [Column("DESC_VIDEO")]
        [StringLength(120)]
        public string Descricao { get; set; } // Descrição do vídeo

        [Column("URL_VIDEO")]
        [StringLength(200)]
        public string Url { get; set; } // URL do vídeo

        [Column("DURACAO_VIDEO")]
        [Required]

        public int DuracaoSegundos { get; set; } // Duração do vídeo em segundos

        [Column("PATH_VIDEO")]
        [StringLength(200)]
        public string FilePath { get; set; } // Caminho do arquivo de vídeo no servidor

        public Curso? Curso { get; set; } // Curso ao qual o vídeo pertence



    }
}
