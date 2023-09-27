using FinanceFlix.API.Entities;
using FinanceFlix.Application.Interfaces;
using FinanceFlix.Application.ViewModels;
using FinanceFlix.Application.ViewModels.Curso;
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

        public async Task<bool> Add(AddCursoViewModel curso)
        {
            try
            {
                Curso cursoEntity = new Curso(

                    curso.Nome,
                    curso.Descricao,
                    curso.Imagem,
                    curso.CategoriaId
                );


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

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<ListCursoViewModel>> GetAll()
        {


            try
            {
                var cursos = await _cursoService.GetAll();

                if (cursos != null)
                {
                    IList<ListCursoViewModel> cursoViewModels = new List<ListCursoViewModel>();

                    foreach (var curso in cursos)
                    {
                        cursoViewModels.Add(new ListCursoViewModel
                        {/*
                            Id = curso.Id,
                            Nome = curso.Nome,
                            Descricao = curso.Descricao,
                            Imagem = curso.ImagemUrl,
                            CategoriaId = curso.CategoriaId*/
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

        public async Task<IList<ListCursoViewModel>> GetByCategoriaCurso(int id)
        {
            try
            {
                var cursos = await _cursoService.GetByCategoriaCurso(id);

                if (cursos != null)
                {
                    IList<ListCursoViewModel> cursoViewModels = new List<ListCursoViewModel>();

                    foreach (var curso in cursos)
                    {
                        cursoViewModels.Add(new ListCursoViewModel
                        {
                            /* Id = curso.Id,
                             Nome = curso.Nome,
                             Descricao = curso.Descricao,
                             ImagemUrl = curso.ImagemUrl,
                             CategoriaId = curso.CategoriaId*/
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

        public async Task<ListCursoViewModel> GetById(int id)
        {
            try
            {
                var curso = await _cursoService.GetById(id);

                if (curso != null)
                {
                    ListCursoViewModel cursoViewModel = new ListCursoViewModel();
                    /*
                    cursoViewModel.Id = curso.Id;
                    cursoViewModel.Nome = curso.Nome;
                    cursoViewModel.Descricao = curso.Descricao;
                    cursoViewModel.ImagemUrl = curso.ImagemUrl;
                    cursoViewModel.CategoriaId = curso.CategoriaId;
                    */

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

        public Task<bool> Update(EditCursoViewModel curso)
        {
            throw new NotImplementedException();
        }
    }
}
