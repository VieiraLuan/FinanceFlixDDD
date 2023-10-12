using FinanceFlix.API.Entities;
using FinanceFlix.Application.ViewModels.Video.Request;
using FinanceFlix.Application.ViewModels.Video.Response;
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

        Task<bool> Delete(Guid id);

        Task<ListVideoResponseViewModel> GetById(Guid id);

        Task<IList<ListVideoResponseViewModel>> GetAll();

        Task<string> WatchVideoUrl(Guid id);

        Task<string> WatchVideoFilePath(Guid id);

        Task<bool> AddVideoCurso(AddVideoToCursoRequestViewModel video);

        Task <IList<ListVideoResponseViewModel>> GetAllVideosByCurso(Guid idCurso);




    }
}
