using FinanceFlix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FinanceFlix.Application.ViewModels.Video.Request
{
    public class AddVideoRequestViewModel
    {


        [Required]
        [StringLength(80, ErrorMessage = "O nome do video deve ter até 80 caracteres")]
        public string Nome { get; set; } // Título do vídeo


        [StringLength(120, ErrorMessage = "A descrição do video deve ter até 120 caracteres")]
        public string Descricao { get; set; } // Descrição do vídeo

        [Required]

        public int DuracaoSegundos { get; set; } // Duração do vídeo em segundos

        public IFormFile videoFile { get; set; }

        public Guid CursoId { get; set; }


    }
}
