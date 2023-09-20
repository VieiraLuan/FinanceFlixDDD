using FinanceFlix.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        Task<IList<Video>> GetByCategoria(int id);

    }
}
