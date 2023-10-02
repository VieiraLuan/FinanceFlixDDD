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
    public class VideoApplicationService : IVideoApplicationService
    {

        private readonly IVideoService _videoService;

        public VideoApplicationService(IVideoService videoService)
        {
            _videoService = videoService;
        }

        public Task<bool> Add(VideoViewModel video)
        {
            try
            {
                var videoEntity = new Video(
                        video.Nome,
                        video.Descricao,
                        video.Url,
                        video.DuracaoSegundos,
                        video.FilePath

                    );
                return _videoService.Add(videoEntity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> AddVideoCurso(Guid idVideo, Guid idCurso)
        {
            try
            {
                return await _videoService.AddVideoCurso(idVideo, idCurso);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<bool> Delete(VideoViewModel video)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<VideoViewModel>> GetAll()
        {
            try
            {
                var videos = await _videoService.GetAll();

                if (videos != null)
                {
                    IList<VideoViewModel> videoViewModels = new List<VideoViewModel>();

                    foreach (var video in videos)
                    {
                        VideoViewModel videoViewModel = new VideoViewModel();
                        videoViewModel.Id = video.Id;
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

        public async Task<IList<VideoViewModel>> GetAllVideosByCurso(Guid idCurso)
        {
            try
            {
                var videos = await _videoService.GetAllVideosByCurso(idCurso);
                IList<VideoViewModel> videoViewModels = new List<VideoViewModel>();
             

                if (videos != null)
                {
                    foreach(var item in videos)
                    {
                        VideoViewModel videoViewModel = new VideoViewModel();
                        videoViewModel.Id = item.Id;
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

        public Task<VideoViewModel> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(VideoViewModel video)
        {
            throw new NotImplementedException();
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
