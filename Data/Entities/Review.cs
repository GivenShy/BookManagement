using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("Review")]
    public class Review
    {
        public string Email { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }
    }
}
