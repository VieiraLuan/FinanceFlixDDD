using FinanceFlix.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Domain.Interfaces.IServices
{
    public interface IVideoService
    {
        Task<bool> Add(Video video);

        Task<bool> Update(Video video);

        Task<bool> Delete(Video video);

        Task<Video> GetById(Guid id);

        Task<IList<Video>> GetAll();

        Task<string> WatchVideoUrl(Guid id);

        Task<string> WatchVideoFilePath(Guid id);

        Task<bool> AddVideoCurso(Guid idVideo, ICollection<Guid> idCursos);

        Task<IList<Video>> GetAllVideosByCurso(Guid idCurso);


    }
}
