using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Application.ViewModels.Usuario.Request
{
    public class AddUsuarioRequestViewModel
    {
        
        [Required]
        [StringLength(80, ErrorMessage = "O nome deve ter até 80 caracteres")]
        public string Nome { get; set; }

        [Required]
        [StringLength(80, ErrorMessage = "O email deve ter até 80 caracteres")]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        [StringLength(80, ErrorMessage = "O tipo deve ter até 80 caracteres")]
        public string Tipo { get; set; }

        [StringLength(80, ErrorMessage = "O url da foto deve ter até 80 caracteres")]
        public string? FotoUrl { get; set; }

    }
}
