using FinanceFlix.API.Entities;
using FinanceFlix.Data.Context;
using FinanceFlix.Domain.Entities;
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

        public async Task<bool> AddVideoCurso(Guid idVideo, Guid idCurso)
        {
            try
            {
                CursoVideo cursoVideo = new CursoVideo(
                   idCurso,
                   idVideo
                    );

                _context.CursosVideos.Add(cursoVideo);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
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

        public async Task<IList<Video>> GetAllVideosByCurso(Guid idCurso)
        {
            try
            {
                //Recuperando todos os videos por id do curso
                var videos = await _context.CursosVideos.Where(x => x.CursoId == idCurso).ToListAsync();

                if (videos != null)
                {
                    List<Video> videosList = new List<Video>();


                    foreach (var item in videos)
                    {

                        videosList.Add(await _context.Videos.FindAsync(item.VideoId));

                    }

                    foreach (var item in videosList)
                    {
                        Console.WriteLine(item.Id + "ID");
                        Console.WriteLine(item.Nome + "Nome");
                        Console.WriteLine(item.Descricao + "Descricao");
                        Console.WriteLine(item.Url + "Url");


                    }

                    return videosList;
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

        public async Task<Video?> GetById(Guid id)
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

        public async Task<string> GetVideoFilePath(Guid id)
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

        public async Task<string> GetVideoUrl(Guid id)
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
