using FinanceFlix.API.Entities;
using FinanceFlix.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Application.Interfaces
{
    public interface ICategoriaApplicationService
    {
        Task<bool> Add(CategoriaViewModel categoria);

        Task<bool> Update(CategoriaViewModel categoria);

        Task<bool> Delete(CategoriaViewModel categoria);

        Task<CategoriaViewModel> GetById(int id);

        Task<ICollection<CategoriaViewModel>> GetAll();
    }
}
