using FinanceFlix.API.Entities;
using FinanceFlix.Application.ViewModels;
using FinanceFlix.Application.ViewModels.Curso.Request;
using FinanceFlix.Application.ViewModels.Curso.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Application.Interfaces
{
    public interface ICursoApplicationService
    {
        Task<bool> Add(AddCursoRequestViewModel curso);

        Task<bool> AddCursoCategoria(AddCursoCategoriaRequestViewModel curso);

        Task<bool> Update(EditCursoRequestViewModel curso);

        Task<bool> Delete(Guid id);

        Task<ListCursoResponseViewModel> GetById(Guid id);

        Task<IList<ListCursoResponseViewModel>> GetAll();

        Task<IList<ListCursoResponseViewModel>> GetByCategoriaCurso(Guid id);
    }
}
