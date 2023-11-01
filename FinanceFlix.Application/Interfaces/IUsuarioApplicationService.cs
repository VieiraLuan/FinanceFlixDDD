
using FinanceFlix.Application.ViewModels.Usuario.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Application.Interfaces
{
    public interface IUsuarioApplicationService
    {

        Task<UsuarioResponseViewModel> Login(LoginResponseViewModel usuarioLogin);

        Task<bool> Add(AddUsuarioRequestViewModel usuario);

        Task<bool> Update(EditUsuarioRequestViewModel usuario);

        Task<bool> Delete(Guid id);



    }
}
