﻿using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Impl
{
    public class BookServiceImpl : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookServiceImpl(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
    }
}
