using FinanceFlix.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Domain.Interfaces.IServices
{
    public interface ICategoriaService
    {

        Task<bool> Add(Categoria categoria);

        Task<bool> Update(Categoria categoria);

        Task<bool> Delete(int id);

        Task<Categoria> GetById(int id);

        Task<ICollection<Categoria>> GetAll();

    }
}
