using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Application.ViewModels.Curso
{
    public class ListCursoViewModel
    {
        
        public Guid Id { get; set; }
        public string Nome { get;  set; }
        public string Descricao { get;  set; }
        public byte[]? Imagem { get;  set; }

        public Guid CategoriaId { get;  set; }

    }
}
