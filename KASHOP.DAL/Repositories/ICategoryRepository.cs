using KASHOP.DAL.Models;

namespace KASHOP.DAL.Repositories
{
    public interface ICategoryRepository
    {
        int Add(Category category);
        Category? GetByID(int ID);
        IEnumerable<Category> GetAll(bool withTracking = false);
        int Delete(Category category);
        int Update(Category category);
    }
}