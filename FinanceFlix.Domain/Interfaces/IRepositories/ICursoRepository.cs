﻿using FinanceFlix.API.Entities;


namespace FinanceFlix.Domain.Interfaces.IRepositories
{
    public interface ICursoRepository
    {

        Task<bool> Add(Curso categoria);

        Task<bool> Update(Curso categoria);

        Task<bool> Delete(Curso categoria);

        Task<Curso> GetById(int id);

        Task<IList<Curso>> GetAll();

        Task<IList<Curso>> GetByCategoria(int id);

    }
}