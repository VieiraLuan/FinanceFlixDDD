using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Application.ViewModels.Categoria.Request
{
    public class AddCategoriaRequestViewModel
    {

        [StringLength(80, ErrorMessage = "O nome deve ter até 50 caracteres")]
        [Required]
        public string Nome { get; set; }

        [Required]
        [StringLength(120, ErrorMessage = "A descrição deve ter até 120 caracteres")]
        public string Descricao { get; set; }
    }
}
