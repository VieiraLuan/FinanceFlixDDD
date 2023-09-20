﻿using FinanceFlix.API.Entities;


namespace FinanceFlix.Domain.Interfaces.IRepositories
{
    public interface ICategoriaRepository
    {

        Task<bool> Add(Categoria categoria);

        Task<bool> Update(Categoria categoria);

        Task<bool> Delete(Categoria categoria);

        Task<Categoria> GetById(int id);

        Task<IList<Categoria>> GetAll();

    }
}
