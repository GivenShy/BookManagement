using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Book
    {
        public Book() { }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string CategoryName { get; set; }

        public Category Category { get; set; }
    }
}
