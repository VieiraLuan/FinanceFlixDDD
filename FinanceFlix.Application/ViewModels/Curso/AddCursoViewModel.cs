using FinanceFlix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Application.ViewModels.Curso
{
    public class AddCursoViewModel
    {


        
        [StringLength(80, ErrorMessage = "O nome deve ter até 80 caracteres")]
        public string Nome { get;  set; }



        [StringLength(120, ErrorMessage = "A descrição deve ter até 120 caracteres")]
        public string Descricao { get;  set; }

        public byte[]? Imagem { get;  set; }

        public int CategoriaId { get;  set; }


    }
}
