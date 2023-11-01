using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Application.ViewModels.Usuario.Request
{
    public class LoginResponseViewModel
    {



        [Required]
        [StringLength(80, ErrorMessage = "O email deve ter até 80 caracteres")]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }


    }
}
