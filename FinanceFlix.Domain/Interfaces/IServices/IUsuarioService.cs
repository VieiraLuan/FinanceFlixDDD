using FinanceFlix.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Domain.Interfaces.IServices
{
    public interface IUsuarioService
    {
        Task<Usuario> Get(string email, string senha);

        Task<bool> Add(Usuario usuario);

        Task<bool> Update(Usuario usuario);

        Task<bool> Delete(Guid id);
    }
}
