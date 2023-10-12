using FinanceFlix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Application.ViewModels.Video.Response
{
    public class ListVideoResponseViewModel
    {
        public Guid CursoId { get; set; }
        public Guid Id { get; set; }
        public string Nome { get; set; } // Título do vídeo
        public string Descricao { get; set; } // Descrição do vídeo
        public string Url { get; set; } // URL do vídeo
        public int DuracaoSegundos { get; set; } // Duração do vídeo em segundos
        public string? FilePath { get; set; } // Caminho do arquivo de vídeo no servidor




    }
}
