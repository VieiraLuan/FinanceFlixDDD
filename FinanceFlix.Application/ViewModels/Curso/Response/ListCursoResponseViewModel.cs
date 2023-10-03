using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceFlix.Application.ViewModels.Categoria.Response;
using FinanceFlix.Domain.Entities;

namespace FinanceFlix.Application.ViewModels.Curso.Response
{
    public class ListCursoResponseViewModel
    {

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public byte[]? Imagem { get; set; }

        public ListCategoriaResponseViewModel Categoria { get; set; }

    }
}
