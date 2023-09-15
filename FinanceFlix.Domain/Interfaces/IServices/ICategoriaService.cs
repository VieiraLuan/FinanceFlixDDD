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

        bool Add(Categoria categoria);

        bool Update(Categoria categoria);

        bool Delete(Categoria categoria);

        Categoria GetById(Guid id);

        IEnumerable<Categoria> GetAll();

    }
}
