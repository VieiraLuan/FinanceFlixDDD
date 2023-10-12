using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Domain.Interfaces.IRepositories
{
    public interface ICursoVideoRepository
    {
        Task<bool> Delete(Guid id);
    }
}
