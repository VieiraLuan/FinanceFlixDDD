using FinanceFlix.API.Entities;
using FinanceFlix.Data.Context;
using FinanceFlix.Domain.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;


namespace FinanceFlix.Data.Repositories
{
    public class VideoRepository : IVideoRepository
    {

        private readonly DataContext _context;

        public VideoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Video video)
        {
            if (video != null)
            {
                try
                {
                    _context.Videos.Add(video);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    //TODO: Implementar log
                    return false;
                }
            }
            else
            {
                //TODO: Implementar log
                return false;
            }
        }

        public async Task<bool> Delete(Video video)
        {
            if (video != null)
            {
                try
                {
                    _context.Videos.Remove(video);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    //TODO: Implementar log
                    return false;
                }
            }
            else
            {
                //TODO: Implementar log
                return false;
            }
        }

        public async Task<IList<Video>> GetAll()
        {
            try
            {
                var videos = await _context.Videos.ToListAsync();

                if (videos != null)
                {
                    return videos;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //TODO: Implementar log
                return null;
            }
        }

        public async Task<Video?> GetById(int id)
        {
            if (id != null)
            {
                try
                {
                    var video = await _context.Videos.FindAsync(id);

                    if (video != null)
                    {
                        return video;
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
            else
            {
                //TODO: Implementar log
                return null;
            }

        }

        public async Task<string> GetVideoFilePath(int id)
        {
            try
            {
                var video = await _context.Videos.FindAsync(id);

                if (video != null)
                {
                    return video.FilePath;
                }

                return null;

            }
            catch (Exception)
            {
                //TODO: Implementar log
                return null;

            }
        }

        public async Task<string> GetVideoUrl(int id)
        {
            try
            {
                var video = await _context.Videos.FindAsync(id);

                if (video != null)
                {
                    return video.Url;
                }

                return null;

            }
            catch (Exception)
            {
                //TODO: Implementar log
                return null;

            }
        }

        public async Task<bool> Update(Video video)
        {
            if (video != null)
            {
                try
                {
                    _context.Videos.Update(video);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
    }
}
