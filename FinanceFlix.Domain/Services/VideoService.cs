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
            if (video == null)
            {
                return false;
            }
            try
            {
                await _videoRepository.Add(video);
                return true;
            }
            catch (Exception)
            {
                //TODO: Implementar log
                return false;
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
                await _videoRepository.Delete(video);
                return true;
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
                await _videoRepository.Update(video);
                return true;
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
                if (id != Guid.Empty)
                {
                    string url = await _videoRepository.GetVideoFilePath(id);

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
                if (id != Guid.Empty)
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
                return null;

            }
            catch (Exception)
            {
                //TODO: Implementar log
                return null;


            }
        }

        public async Task<IList<Video>> GetByCategoriaCurso(Guid id)
        {
            try
            {
                if (id != Guid.Empty)
                {
                    var videos = await _videoRepository.GetByCategoria(id);

                    if (videos == null)
                    {
                        return null;
                    }
                    else
                    {
                        return videos;
                    }

                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                //todo: implementar log
                return null;
            }
        }

    
    }
}

