using FinanceFlix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Application.ViewModels.Video.Request
{
    public class AddVideoRequestViewModel
    {

        [Column("NOME_VIDEO")]
        [Required]
        [StringLength(80,ErrorMessage ="O nome do video deve ter até 80 caracteres")]
        public string Nome { get; set; } // Título do vídeo

        [Column("DESC_VIDEO")]
        [StringLength(120,ErrorMessage ="A descrição do video deve ter até 120 caracteres")]
        public string Descricao { get; set; } // Descrição do vídeo

        [Column("URL_VIDEO")]
        [StringLength(200, ErrorMessage = "A URL do video deve ter até 200 caracteres")]
        public string Url { get; set; } // URL do vídeo

        [Column("DURACAO_VIDEO")]
        [Required]

        public int DuracaoSegundos { get; set; } // Duração do vídeo em segundos

        [Column("PATH_VIDEO")]
        [StringLength(200, ErrorMessage = "O path do video deve ter até 200 caracteres")]
        public string? FilePath { get; set; } // Caminho do arquivo de vídeo no servidor

        public Guid CursoId { get; set; }


    }
}
