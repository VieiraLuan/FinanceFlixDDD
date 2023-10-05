using FinanceFlix.API.Entities;


namespace FinanceFlix.Domain.Interfaces.IRepositories
{
    public interface IVideoRepository
    {
        Task<bool> Add(Video video);

        Task<bool> Update(Video video);

        Task<bool> Delete(Video video);

        Task<Video> GetById(Guid id);

        Task<string> GetVideoUrl(Guid id);

        Task<string> GetVideoFilePath(Guid id);

        Task<IList<Video>> GetAll();

        Task<bool> AddVideoCurso(Guid idVideo,ICollection<Guid> idCurso);

        Task<IList<Video>> GetAllVideosByCurso(Guid idCurso);



    }
}
