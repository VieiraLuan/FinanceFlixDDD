using FinanceFlix.API.Entities;
using FinanceFlix.Application.ViewModels;
using FinanceFlix.Application.ViewModels.Categoria.Request;
using FinanceFlix.Application.ViewModels.Categoria.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Application.Interfaces
{
    public interface ICategoriaApplicationService
    {
        Task<bool> Add(AddCategoriaRequestViewModel categoria);

        Task<bool> Update(EditCategoriaRequestViewModel categoria);

        Task<bool> Delete(Guid id);

        Task<ListCategoriaResponseViewModel> GetById(Guid id);

        Task<ICollection<ListCategoriaResponseViewModel>> GetAll();
    }
}
