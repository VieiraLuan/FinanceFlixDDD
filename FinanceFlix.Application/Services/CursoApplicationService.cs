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
    public class CursoApplicationService : ICursoApplicationService
    {

        private readonly ICursoService _cursoService;

        public CursoApplicationService(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        public async Task<bool> Add(CursoViewModel curso)
        {
            Curso cursoEntity = new Curso(
                    curso.Id,
                    curso.Nome,
                    curso.Descricao,
                    curso.ImagemUrl,
                    curso.CategoriaId
                );

            try
            {
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

        public Task<bool> Delete(CursoViewModel curso)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<CursoViewModel>> GetAll()
        {


            try
            {
                var cursos = await _cursoService.GetAll();

                if (cursos != null)
                {
                    IList<CursoViewModel> cursoViewModels = new List<CursoViewModel>();

                    foreach (var curso in cursos)
                    {
                        cursoViewModels.Add(new CursoViewModel
                        {
                            Id = curso.Id,
                            Nome = curso.Nome,
                            Descricao = curso.Descricao,
                            ImagemUrl = curso.ImagemUrl,
                            CategoriaId = curso.CategoriaId
                        });
                    }

                    return cursoViewModels;
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

        public async Task<IList<CursoViewModel>> GetByCategoriaCurso(int id)
        {
            try
            {
                var cursos = await _cursoService.GetByCategoriaCurso(id);

                if (cursos != null)
                {
                    IList<CursoViewModel> cursoViewModels = new List<CursoViewModel>();

                    foreach (var curso in cursos)
                    {
                        cursoViewModels.Add(new CursoViewModel
                        {
                            Id = curso.Id,
                            Nome = curso.Nome,
                            Descricao = curso.Descricao,
                            ImagemUrl = curso.ImagemUrl,
                            CategoriaId = curso.CategoriaId
                        });
                    }

                    return cursoViewModels;
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

        public async Task<CursoViewModel> GetById(int id)
        {
            try
            {
                var curso = await _cursoService.GetById(id);

                if (curso != null)
                {
                    CursoViewModel cursoViewModel = new CursoViewModel();

                    cursoViewModel.Id = curso.Id;
                    cursoViewModel.Nome = curso.Nome;
                    cursoViewModel.Descricao = curso.Descricao;
                    cursoViewModel.ImagemUrl = curso.ImagemUrl;
                    cursoViewModel.CategoriaId = curso.CategoriaId;


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

        public Task<bool> Update(CursoViewModel curso)
        {
            throw new NotImplementedException();
        }
    }
}
