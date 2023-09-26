using FinanceFlix.API.Entities;


namespace FinanceFlix.Domain.Interfaces.IRepositories
{
    public interface IVideoRepository
    {
        Task<bool> Add(Video video);

        Task<bool> Update(Video video);

        Task<bool> Delete(Video video);

        Task<Video> GetById(int id);

        Task<string> GetVideoUrl(int id);

        Task<string> GetVideoFilePath(int id);

        Task<IList<Video>> GetAll();

        Task<bool> AddVideoCurso(int idVideo, int idCurso);

        Task<IList<Video>> GetAllVideosByCurso(int idCurso);



    }
}
