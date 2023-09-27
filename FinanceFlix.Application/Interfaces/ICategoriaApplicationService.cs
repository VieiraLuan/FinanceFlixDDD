using FinanceFlix.API.Entities;
using FinanceFlix.Application.ViewModels;
using FinanceFlix.Application.ViewModels.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Application.Interfaces
{
    public interface ICategoriaApplicationService
    {
        Task<bool> Add(AddCategoriaViewModel categoria);

        Task<bool> Update(EditCategoriaViewModel categoria);

        Task<bool> Delete(int id);

        Task<ListCategoriaViewModel> GetById(int id);

        Task<ICollection<ListCategoriaViewModel>> GetAll();
    }
}
