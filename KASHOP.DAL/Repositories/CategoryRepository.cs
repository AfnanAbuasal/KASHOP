using KASHOP.DAL.Data;
using KASHOP.DAL.DTO.Responses;
using KASHOP.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(Category category)
        {
            _context.Categories.Add(category);
            return _context.SaveChanges();
        }

        public int Delete(Category category)
        {
            _context.Categories.Remove(category);
            return _context.SaveChanges();
        }

        public IEnumerable<Category> GetAll(bool withTracking = false)
        {
            if(withTracking) _context.Categories.ToList(); 
            return _context.Categories.AsNoTracking().ToList();
        }

        public Category? GetByID(int ID)
        {
            return _context.Categories.Find(ID);
        }

        public int Update(Category category)
        {
            _context.Categories.Update(category);
            return _context.SaveChanges();
        }
    }
}
