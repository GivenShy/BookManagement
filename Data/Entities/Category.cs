using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("Category")]
    public class Category
    {
        public Category() { }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
