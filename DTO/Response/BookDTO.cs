﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Response
{
    public class BookDTO
    {
        public BookDTO() { }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
        public double AvgRating { get; set; }

    }
}
