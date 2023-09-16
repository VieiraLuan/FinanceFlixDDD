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

        Task<bool> Add(Video categoria);

        Task<bool> Update(Video categoria);

        Task<bool> Delete(Video categoria);

        Task<Video> GetById(Guid id);

        Task<IEnumerable<Video>> GetAll();


    }
}
