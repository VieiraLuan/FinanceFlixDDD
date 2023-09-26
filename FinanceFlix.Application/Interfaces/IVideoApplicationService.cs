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

        Task<VideoViewModel> GetById(int id);

        Task<IList<VideoViewModel>> GetAll();

        Task<string> WatchVideoUrl(int id);

        Task<string> WatchVideoFilePath(int id);

        Task<bool> AddVideoCurso(int idVideo, int idCurso);

        Task <IList<VideoViewModel>> GetAllVideosByCurso(int idCurso);




    }
}
