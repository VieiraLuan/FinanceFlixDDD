using FinanceFlix.API.Entities;
using FinanceFlix.Application.Interfaces;
using FinanceFlix.Application.ViewModels.Video.Request;
using FinanceFlix.Application.ViewModels.Video.Response;
using FinanceFlix.Domain.Entities;
using FinanceFlix.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                var videoCreated = new Video(video.Nome, video.Descricao, video.Url, video.DuracaoSegundos,
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

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                if (!id.Equals(Guid.Empty))
                {
                    if (await _videoService.Delete(await _videoService.GetById(id)) == true)
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
            catch (Exception)
            {
                //Implementar log
                return false;
            }
        }

        public async Task<IList<ListVideoResponseViewModel>> GetAll()
        {
            try
            {

                var videos = await _videoService.GetAll();

                var listaVideos = new List<ListVideoResponseViewModel>();

                var video = new ListVideoResponseViewModel();

                foreach (var item in videos)
                {

                    video.Id = item.Id;
                    video.Nome = item.Nome;
                    video.Descricao = item.Descricao;
                    video.Url = item.Url;
                    video.DuracaoSegundos = item.DuracaoSegundos;
                    video.FilePath = item.FilePath;
                    listaVideos.Add(video);

                }

                return listaVideos;

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<IList<ListVideoResponseViewModel>> GetAllVideosByCurso(Guid idCurso)
        {
            try
            {
                var videos = await _videoService.GetAllVideosByCurso(idCurso);
                var listaVideos = new List<ListVideoResponseViewModel>();
                var cursoVideo = new CursoVideo();
                var cursoId = new Guid();


                if (videos != null)
                {
                    foreach (var item in videos)
                    {
                        var video = new ListVideoResponseViewModel();

                        foreach (var id in item.CursosVideos)
                        {
                            cursoId = id.CursoId;
                        }

                        video.CursoId = cursoId;
                        video.Id = item.Id;
                        video.Nome = item.Nome;
                        video.Descricao = item.Descricao;
                        video.Url = item.Url;
                        video.DuracaoSegundos = item.DuracaoSegundos;
                        video.FilePath = item.FilePath;
                        listaVideos.Add(video);
                    }

                    return listaVideos;

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

        public Task<ListVideoResponseViewModel> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(EditVideoRequestViewModel video)
        {
            try
            {
                if (video != null)
                {
                    var videoEntity = new Video(video.Id, video.Nome, video.Descricao, video.Url, video.DuracaoSegundos, video.FilePath, video.CursoId);

                    await _videoService.Update(videoEntity);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
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
