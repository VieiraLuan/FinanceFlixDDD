using FinanceFlix.API.Entities;
using FinanceFlix.Application.ViewModels;
using FinanceFlix.Application.ViewModels.Curso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Application.Interfaces
{
    public interface ICursoApplicationService
    {
        Task<bool> Add(AddCursoViewModel curso);

        Task<bool> Update(EditCursoViewModel curso);

        Task<bool> Delete(Guid id);

        Task<ListCursoViewModel> GetById(Guid id);

        Task<IList<ListCursoViewModel>> GetAll();

        Task<IList<ListCursoViewModel>> GetByCategoriaCurso(Guid id);
    }
}
