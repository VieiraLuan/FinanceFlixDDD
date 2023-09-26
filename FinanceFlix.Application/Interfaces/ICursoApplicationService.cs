using FinanceFlix.API.Entities;
using FinanceFlix.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Application.Interfaces
{
    public interface ICursoApplicationService
    {
        Task<bool> Add(CursoViewModel curso);

        Task<bool> Update(CursoViewModel curso);

        Task<bool> Delete(CursoViewModel curso);

        Task<CursoViewModel> GetById(int id);

        Task<IList<CursoViewModel>> GetAll();

        Task<IList<CursoViewModel>> GetByCategoriaCurso(int id);
    }
}
