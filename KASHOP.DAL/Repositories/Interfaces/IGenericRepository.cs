using KASHOP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        int Add(T entity);
        T? GetByID(int ID);
        IEnumerable<T> GetAll(bool withTracking = false);
        int Delete(T entity);
        int Update(T entity);
    }
}
