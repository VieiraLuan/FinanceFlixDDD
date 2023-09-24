using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceFlix.API.Entities;

namespace FinanceFlix.Application.ViewModels
{
    public class CategoriaViewModel
    {

    
       // public int Id { get;  set; }
        
        [StringLength(80,ErrorMessage = "O tamanho do {0} deve ser")]
        
        public string Nome { get;  set; }

        [Column("DESC_CATEGORIA")]

        [StringLength(120)]
        public string Descricao { get;  set; }

       // public ICollection<Curso>? Cursos { get;  set; }


    }
}
