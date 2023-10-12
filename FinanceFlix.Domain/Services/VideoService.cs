using FinanceFlix.API.Entities;
using FinanceFlix.Domain.Interfaces.IRepositories;
using FinanceFlix.Domain.Interfaces.IServices;


namespace FinanceFlix.Domain.Services
{
    public class VideoService : IVideoService
    {
        private readonly IVideoRepository _videoRepository;

        public VideoService(IVideoRepository videoService)
        {
            _videoRepository = videoService;
        }

        public async Task<bool> Add(Video video)
        {

            try
            {
                if (video == null)
                {
                    return false;
                }

                return await _videoRepository.Add(video);


            }
            catch (Exception)
            {
                //TODO: Implementar log
                return false;
            }


        }

        public Task<bool> AddVideoCurso(Guid idVideo, ICollection<Guid> idCursos)
        {
            try
            {
                return _videoRepository.AddVideoCurso(idVideo, idCursos);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Delete(Video video)
        {
            if (video == null)
            {
                return false;
            }
            try
            {
                return await _videoRepository.Delete(video);

            }
            catch (Exception)
            {
                //TODO: Implementar log
                return false;
            }
        }

        public async Task<IList<Video>> GetAll()
        {
            try
            {
                return await _videoRepository.GetAll();
            }
            catch (Exception)
            {
                //TODO: Implementar log
                return null;
            }
        }

        public async Task<IList<Video>> GetAllVideosByCurso(Guid idCurso)
        {
            try
            {
                return await _videoRepository.GetAllVideosByCurso(idCurso);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Video> GetById(Guid id)
        {
            try
            {
                return await _videoRepository.GetById(id);
            }
            catch (Exception)
            {
                //TODO: Implementar log
                return null;

            }
        }

        public async Task<bool> Update(Video video)
        {
            if (video == null)
            {
                return false;
            }
            try
            {
                return await _videoRepository.Update(video);

            }
            catch (Exception)
            {
                //TODO: Implementar log
                return false;
            }
        }

        public async Task<string> WatchVideoFilePath(Guid id)
        {
            try
            {
                if (!id.Equals(Guid.Empty))
                {
                    string path = await _videoRepository.GetVideoFilePath(id);

                    if (path != null)
                    {
                        return path;

                    }
                    else
                    {
                        //TODO: Implementar log
                        return null;
                    }
                }
                return null;

            }
            catch (Exception)
            {
                //TODO: Implementar log
                return null;
            }
        }

        public async Task<string> WatchVideoUrl(Guid id)
        {
            try
            {
                if (!id.Equals(Guid.Empty))
                {
                    string url = await _videoRepository.GetVideoUrl(id);

                    if (url != null)
                    {
                        return url;

                    }
                    else
                    {
                        //TODO: Implementar log
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                //TODO: Implementar log
                return null;


            }
        }




    }
}

