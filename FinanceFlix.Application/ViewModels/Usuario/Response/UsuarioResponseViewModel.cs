using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Application.ViewModels.Usuario.Request
{
    public class UsuarioResponseViewModel
    {
       
        public Guid Id { get; set; }

        public string Token { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }
        
        public string Tipo { get; set; }
        public string FotoUrl { get; set; }

    }
}
