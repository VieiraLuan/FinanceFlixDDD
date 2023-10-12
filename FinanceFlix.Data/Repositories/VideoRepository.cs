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
        private readonly ICursoVideoRepository _cursoVideoRepository;


        public VideoRepository(DataContext context, ICursoVideoRepository cursoVideoRepository)
        {
            _context = context;
            _cursoVideoRepository = cursoVideoRepository;


        }

        public async Task<bool> Add(Video video)
        {
            if (video != null)
            {
                try
                {
                    _context.Videos.Add(video);
                    if (await _context.SaveChangesAsync() > 0)
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

        public async Task<bool> AddVideoCurso(Guid idVideo, ICollection<Guid> idCursos)
        {
            try
            {
                foreach (var item in idCursos)
                {
                    CursoVideo cursoVideo = new CursoVideo(
                    item,
                    idVideo
                    );
                    _context.CursosVideos.Add(cursoVideo);

                }

                if (await _context.SaveChangesAsync() > 0)
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
                    if (await _context.SaveChangesAsync() > 0)
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
                return await _context.Videos.AsNoTracking().ToListAsync();

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
                var videos = await _context.CursosVideos.AsNoTracking().Where(x => x.CursoId == idCurso).ToListAsync();

                if (videos != null)
                {
                    List<Video> videosList = new List<Video>();


                    foreach (var item in videos)
                    {

                        videosList.Add(await _context.Videos.FindAsync(item.VideoId));

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

        public async Task<Video> GetById(Guid id)
        {
            try
            {
                if (!id.Equals(Guid.Empty))
                {

                    return await _context.Videos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);



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


        public async Task<string> GetVideoFilePath(Guid id)
        {
            try
            {
                var video = await _context.Videos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                if (video != null && video.FilePath != null)
                {
                    return video.FilePath;
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

        public async Task<string> GetVideoUrl(Guid id)
        {
            try
            {
                var video = await _context.Videos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

                if (video != null)
                {
                    return video.Url;
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

        public async Task<bool> Update(Video video)
        {
            //Em andamento
            if (video != null)
            {
                try
                {

                    //Video que será atualizado
                    var myVideo = await _context.Videos.Include(cv => cv.CursosVideos).FirstOrDefaultAsync(x => x.Id == video.Id);
                    var cursoId = myVideo.CursosVideos.Select(x => x.CursoId).ToList();
                    var videoId = myVideo.CursosVideos.Select(x => x.VideoId).First();



                    if (myVideo != null)

                    //tentei, falta testar
                    {
                        //Adicionando relacionamento novo
                        await AddVideoCurso(videoId, cursoId);

                        //To do aqui

                        //Dar um jeito de remover a tabela de relacionamento
                        _context.CursosVideos.RemoveRange(myVideo.CursosVideos);
                        await _context.SaveChangesAsync();

                        //Atualizando o video

                        _context.Videos.Update(video);
                        await _context.SaveChangesAsync();


                        return true;
                    }
                    else
                    {
                        return false;
                    }

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
