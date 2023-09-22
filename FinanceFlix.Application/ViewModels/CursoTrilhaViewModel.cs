using FinanceFlix.API.Entities;
using FinanceFlix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Application.ViewModels
{
    public class CursoTrilhaViewModel
    {
        public int CursoVideoId { get; set; }

        public int CursoId { get; set; }

        public int TrilhaId { get; set; }


        public Curso Curso { get; set; }


        public Trilha Trilha { get; set; }

    }
}
