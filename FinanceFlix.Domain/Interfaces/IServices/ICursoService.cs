﻿using FinanceFlix.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Domain.Interfaces.IServices
{
    public interface ICursoService
    {
        Task<bool> Add(Curso curso);

        Task<bool> Update(Curso curso);

        Task<bool> Delete(Curso curso);

        Task<IList<Curso>> GetAll();

        Task<IList<Curso>> GetByCategoriaCurso(int id);

        Task<Curso> GetById(int id);
    }
}