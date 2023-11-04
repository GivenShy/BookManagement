﻿using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Impl
{
    public class CategoryRepositoryImpl:ICategoryRepository
    {
        private readonly BookManagementContext _context;
        public CategoryRepositoryImpl(BookManagementContext context)
        {
            _context = context;
        }

        public void Save(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public Category Find(string name)
        {
            return _context.Categories.Where(c => c.Name == name).FirstOrDefault();

        }
    }
}
