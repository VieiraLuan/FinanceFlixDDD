using FinanceFlix.API.Entities;
using FinanceFlix.Application.ViewModels.Video.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Application.Interfaces
{
    public interface IVideoApplicationService
    {
        Task<bool> Add(AddVideoRequestViewModel video);

        Task<bool> Update(EditVideoRequestViewModel video);

        Task<bool> Delete(AddVideoRequestViewModel video);

        Task<AddVideoRequestViewModel> GetById(Guid id);

        Task<IList<AddVideoRequestViewModel>> GetAll();

        Task<string> WatchVideoUrl(Guid id);

        Task<string> WatchVideoFilePath(Guid id);

        Task<bool> AddVideoCurso(AddVideoToCursoRequestViewModel video);

        Task <IList<AddVideoRequestViewModel>> GetAllVideosByCurso(Guid idCurso);




    }
}
