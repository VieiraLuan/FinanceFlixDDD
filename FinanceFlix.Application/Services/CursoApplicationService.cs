using FinanceFlix.API.Entities;
using FinanceFlix.Application.Interfaces;
using FinanceFlix.Application.ViewModels;
using FinanceFlix.Application.ViewModels.Categoria.Response;
using FinanceFlix.Application.ViewModels.Curso.Request;
using FinanceFlix.Application.ViewModels.Curso.Response;
using FinanceFlix.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Application.Services
{
    public class CursoApplicationService : ICursoApplicationService
    {

        private readonly ICursoService _cursoService;
        private readonly ICategoriaService _categoriaService;

        public CursoApplicationService(ICursoService cursoService, ICategoriaService categoriaService)
        {
            _cursoService = cursoService;
            _categoriaService = categoriaService;

        }


        public async Task<bool> Add(AddCursoRequestViewModel curso)
        {
            try
            {
                var categoriaEntity = await _categoriaService.GetById(curso.CategoriaId);
               
                if (categoriaEntity != null)
                {
                    Curso cursoEntity = new Curso(curso.Nome, curso.Descricao, curso.Imagem, curso.CategoriaId, categoriaEntity);


                    if (await _cursoService.Add(cursoEntity) == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                //todo: logar erro
                throw;
            }

        }

        public async Task<bool> AddCursoCategoria(AddCursoCategoriaRequestViewModel curso)
        {
            try
            {
                var categoriaEntity = new Categoria(curso.Categoria.Nome, curso.Categoria.Descricao, null);
                var cursoEntity = new Curso(curso.Nome, curso.Descricao, curso.Imagem, categoriaEntity.Id, categoriaEntity);


                if (await _cursoService.Add(cursoEntity) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                //todo: logar erro
                throw;
            }
        }

        public Task<bool> Delete(Guid id)
        {
            try
            {
                if (!id.Equals(Guid.Empty))
                {
                    return _cursoService.Delete(id);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IList<ListCursoResponseViewModel>> GetAll()
        {


            try
            {
                var cursos = await _cursoService.GetAll();

                if (cursos != null)
                {
                    IList<ListCursoResponseViewModel> listaCursos = new List<ListCursoResponseViewModel>();


                    foreach (var curso in cursos)
                    {
                        ListCategoriaResponseViewModel categoria = new ListCategoriaResponseViewModel();
                        categoria.Id = curso.Categoria.Id;
                        categoria.Nome = curso.Categoria.Nome;
                        categoria.Descricao = curso.Categoria.Descricao;
                        categoria.CreatedDate = curso.Categoria.CreatedDate;

                        listaCursos.Add(new ListCursoResponseViewModel
                        {
                            Id = curso.Id,
                            Nome = curso.Nome,
                            Descricao = curso.Descricao,
                            Imagem = curso.ImagemUrl,
                            Categoria = categoria


                        });

                    }

                    return listaCursos;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IList<ListCursoResponseViewModel>> GetByCategoriaCurso(Guid id)
        {
            try
            {
                var cursos = await _cursoService.GetByCategoriaCurso(id);

                if (cursos != null)
                {
                    IList<ListCursoResponseViewModel> listaCursos = new List<ListCursoResponseViewModel>();


                    foreach (var curso in cursos)
                    {
                        ListCategoriaResponseViewModel categoria = new ListCategoriaResponseViewModel();
                        categoria.Id = curso.Categoria.Id;
                        categoria.Nome = curso.Categoria.Nome;
                        categoria.Descricao = curso.Categoria.Descricao;
                        categoria.CreatedDate = curso.Categoria.CreatedDate;

                        listaCursos.Add(new ListCursoResponseViewModel
                        {
                            Id = curso.Id,
                            Nome = curso.Nome,
                            Descricao = curso.Descricao,
                            Imagem = curso.ImagemUrl,
                            Categoria = categoria


                        });

                    }

                    return listaCursos;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ListCursoResponseViewModel> GetById(Guid id)
        {
            try
            {
                var curso = await _cursoService.GetById(id);

                if (curso != null)
                {
                    ListCursoResponseViewModel cursoViewModel = new ListCursoResponseViewModel();
                    ListCategoriaResponseViewModel categoria = new ListCategoriaResponseViewModel();
                    categoria.Id = curso.Categoria.Id;
                    categoria.Nome = curso.Categoria.Nome;
                    categoria.Descricao = curso.Categoria.Descricao;
                    categoria.CreatedDate = curso.Categoria.CreatedDate;

                    cursoViewModel.Id = curso.Id;
                    cursoViewModel.Nome = curso.Nome;
                    cursoViewModel.Descricao = curso.Descricao;
                    cursoViewModel.Imagem = curso.ImagemUrl;
                    cursoViewModel.Categoria = categoria;

                    return cursoViewModel;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<bool> Update(EditCursoRequestViewModel curso)
        {
            try
            {
                Curso cursoEntity = new Curso(curso.Id,curso.Nome,curso.Descricao,curso.Imagem,curso.CategoriaId,null,null);

                return _cursoService.Update(cursoEntity);

            }
            catch (Exception ex)
            {
                //Todo: Implementar log 
                throw ex;

            }

        }
    }
}
