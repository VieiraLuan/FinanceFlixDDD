using FinanceFlix.API.Entities;
using FinanceFlix.Application.Interfaces;
using FinanceFlix.Application.ViewModels.Video.Request;
using FinanceFlix.Domain.Entities;
using FinanceFlix.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Application.Services
{
    public class VideoApplicationService : IVideoApplicationService
    {

        private readonly IVideoService _videoService;

        public VideoApplicationService(IVideoService videoService)
        {
            _videoService = videoService;
        }

        public async Task<bool> Add(AddVideoRequestViewModel video)
        {
            try
            {
                var videoCreated = new Video(video.Nome,video.Descricao,video.Url,video.DuracaoSegundos,
                video.FilePath);

                ICollection<CursoVideo> cursosVideos = new List<CursoVideo>();  
               
               cursosVideos.Add(new CursoVideo(video.CursoId, videoCreated.Id));
                

                var videoEntity = new Video(videoCreated.Id, videoCreated.Nome, videoCreated.Descricao
                    , videoCreated.Url, videoCreated.DuracaoSegundos, videoCreated.FilePath, cursosVideos);


                return await _videoService.Add(videoEntity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> AddVideoCurso(AddVideoToCursoRequestViewModel video)
        {
            try
            {
                return await _videoService.AddVideoCurso(video.VideoId, video.CursoIds);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<bool> Delete(AddVideoRequestViewModel video)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<AddVideoRequestViewModel>> GetAll()
        {
            try
            {
                var videos = await _videoService.GetAll();

                if (videos != null)
                {
                    IList<AddVideoRequestViewModel> videoViewModels = new List<AddVideoRequestViewModel>();

                    foreach (var video in videos)
                    {
                        AddVideoRequestViewModel videoViewModel = new AddVideoRequestViewModel();
                        //videoViewModel.Id = video.Id;
                        videoViewModel.Nome = video.Nome;
                        videoViewModel.Descricao = video.Descricao;
                        videoViewModel.Url = video.Url;
                        videoViewModel.DuracaoSegundos = video.DuracaoSegundos;
                        videoViewModel.FilePath = video.FilePath;

                        videoViewModels.Add(videoViewModel);
                    }

                    return videoViewModels;

                }
                else
                {
                    return null;
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IList<AddVideoRequestViewModel>> GetAllVideosByCurso(Guid idCurso)
        {
            try
            {
                var videos = await _videoService.GetAllVideosByCurso(idCurso);
                IList<AddVideoRequestViewModel> videoViewModels = new List<AddVideoRequestViewModel>();


                if (videos != null)
                {
                    foreach (var item in videos)
                    {
                        AddVideoRequestViewModel videoViewModel = new AddVideoRequestViewModel();
                        //videoViewModel.Id = item.Id;
                        videoViewModel.Nome = item.Nome;
                        videoViewModel.Descricao = item.Descricao;
                        videoViewModel.Url = item.Url;
                        videoViewModel.DuracaoSegundos = item.DuracaoSegundos;
                        videoViewModel.FilePath = item.FilePath;


                        videoViewModels.Add(videoViewModel);
                    }

                    return videoViewModels;

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<AddVideoRequestViewModel> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(EditVideoRequestViewModel video)
        {
            //parei aqui, pegar video e atualizar os dados e salvar
        }

        public Task<string> WatchVideoFilePath(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> WatchVideoUrl(Guid id)
        {
            try
            {
                return await _videoService.WatchVideoUrl(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
