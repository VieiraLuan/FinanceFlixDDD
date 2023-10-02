using FinanceFlix.API.Entities;
using FinanceFlix.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Application.Interfaces
{
    public interface IVideoApplicationService
    {
        Task<bool> Add(VideoViewModel video);

        Task<bool> Update(VideoViewModel video);

        Task<bool> Delete(VideoViewModel video);

        Task<VideoViewModel> GetById(Guid id);

        Task<IList<VideoViewModel>> GetAll();

        Task<string> WatchVideoUrl(Guid id);

        Task<string> WatchVideoFilePath(Guid id);

        Task<bool> AddVideoCurso(Guid idVideo, Guid idCurso);

        Task <IList<VideoViewModel>> GetAllVideosByCurso(Guid idCurso);




    }
}
