using FinanceFlix.API.Entities;
using FinanceFlix.Application.Interfaces;
using FinanceFlix.Application.ViewModels;
using FinanceFlix.Application.ViewModels.Categoria.Request;
using FinanceFlix.Application.ViewModels.Categoria.Response;
using FinanceFlix.Domain.Interfaces.IRepositories;
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

        public async Task<bool> Add(AddCategoriaRequestViewModel categoria)
        {
            try
            {
                Categoria categoriaEntity = new Categoria(

                    categoria.Nome,
                    categoria.Descricao,
                    null

                    );

                return await _categoriaService.Add(categoriaEntity);

            }
            catch (Exception ex)
            {
                //Todo: Implementar log 
                throw ex;
            }

        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                if (id.Equals(Guid.Empty))
                    return false;

                return await _categoriaService.Delete(id);

            }
            catch (Exception ex)
            {
                //Todo: Implementar log
                throw ex;
            }
        }

        public async Task<ICollection<ListCategoriaResponseViewModel>> GetAll()
        {
            try
            {


                ICollection<Categoria> categorias = await _categoriaService.GetAll();

                if (categorias == null)
                    return null;

                var categoriasViewModel = new List<ListCategoriaResponseViewModel>();

                foreach (var categoria in categorias)
                {
                    var categoriaViewModel = new ListCategoriaResponseViewModel
                    {
                        Id = categoria.Id,
                        Nome = categoria.Nome,
                        Descricao = categoria.Descricao,
                        CreatedDate = (DateTime)categoria.CreatedDate
                        
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

        public async Task<ListCategoriaResponseViewModel> GetById(Guid id)
        {
            try
            {
                if (id.Equals(Guid.Empty))
                    return null;

                Categoria categoria = await _categoriaService.GetById(id);

                if (categoria == null)
                    return null;


                var categoriaViewModel = new ListCategoriaResponseViewModel
                {
                    Id = categoria.Id,
                    Nome = categoria.Nome,
                    Descricao = categoria.Descricao,
                    CreatedDate = (DateTime)categoria.CreatedDate
                };

                return categoriaViewModel;
            }
            catch (Exception ex)
            {
                //Todo: Implementar log
                throw ex;
            }
        }

        public Task<bool> Update(EditCategoriaRequestViewModel categoria)
        {
            try
            {
                Categoria categoriaEntity = new Categoria(categoria.Id, categoria.Nome, categoria.Descricao, null);

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
