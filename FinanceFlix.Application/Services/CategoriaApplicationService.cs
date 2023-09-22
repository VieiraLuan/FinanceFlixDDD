using FinanceFlix.API.Entities;
using FinanceFlix.Application.Interfaces;
using FinanceFlix.Application.ViewModels;
using FinanceFlix.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace FinanceFlix.Application.Services
{
    public class CategoriaApplicationService : ICategoriaApplicationService
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaApplicationService(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        public async Task<bool> Add(CategoriaViewModel categoria)
        {
            try
            {
                var categoriaEntity = new Categoria
                    (
                    categoria.Id, categoria.Nome, categoria.Descricao
                    );

                return await _categoriaService.Add(categoriaEntity);

            }
            catch (Exception ex)
            {
                //Todo: Implementar log 
                throw ex;
            }

        }

        public async Task<bool> Delete(CategoriaViewModel categoria)
        {
            try
            {
                var categoriaEntity = new Categoria
                   (
                   categoria.Id, categoria.Nome, categoria.Descricao
                    );

                return await _categoriaService.Delete(categoriaEntity);

            }
            catch (Exception ex)
            {
                //Todo: Implementar log
                throw ex;
            }
        }

        public async Task<IEnumerable<CategoriaViewModel>> GetAll()
        {
            try
            {

              
                IEnumerable<Categoria> categorias = await _categoriaService.GetAll();

                if (categorias == null)
                    return null;

                var categoriasViewModel = new List<CategoriaViewModel>();

                foreach (var categoria in categorias)
                {
                    var categoriaViewModel = new CategoriaViewModel
                    {
                        Id = categoria.Id,
                        Nome = categoria.Nome,
                        Descricao = categoria.Descricao
                    };

                    categoriasViewModel.Add(categoriaViewModel);
                }

                return categoriasViewModel; 
            }
            catch (Exception ex)
            {
                //Todo: Implementar log
                throw;
            }
        }

        public async Task<CategoriaViewModel> GetById(int id)
        {
            try
            {
                Categoria categoria = await _categoriaService.GetById(id);

                if (categoria == null)
                    return null;


                var categoriaViewModel = new CategoriaViewModel
                {
                    Id = categoria.Id,
                    Nome = categoria.Nome,
                    Descricao = categoria.Descricao
                };

                return categoriaViewModel;
            }
            catch (Exception ex)
            {
                //Todo: Implementar log
                throw ex;
            }
        }

        public Task<bool> Update(CategoriaViewModel categoria)
        {
            try
            {
                var categoriaEntity = new Categoria
                    (
                                       categoria.Id, categoria.Nome, categoria.Descricao
                                                          );

                return _categoriaService.Update(categoriaEntity);

            }
            catch (Exception ex)
            {
                //Todo: Implementar log 
                throw ex;

            }
        }
    }
}
