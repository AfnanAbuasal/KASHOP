using KASHOP.DAL.DTO.Requests;
using KASHOP.DAL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.Services.Interfaces
{
    public interface IGenericService<TRequest, TResponse, TEntity>
    {
        int Create(TRequest request);
        IEnumerable<TResponse> GetAll();
        TResponse? GetByID(int ID);
        int Delete(int ID);
        int Update(int ID, TRequest request);
        bool ToggleStatus(int ID);
    }
}
