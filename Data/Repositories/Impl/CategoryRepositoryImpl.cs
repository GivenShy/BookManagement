using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Impl
{
    public class CategoryRepositoryImpl:ICategoryService
    {
        private readonly BookManagementContext _context;
        public CategoryRepositoryImpl(BookManagementContext context)
        {
            _context = context;
        }

        public void save(Category category)
        {
            _context.Categories.Add(category);
        }
    }
}
