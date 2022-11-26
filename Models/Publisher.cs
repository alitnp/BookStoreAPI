using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    [Table("Publishers")]
    public class Publisher : BaseModel
    {
        public ICollection<Book> Books { get; set; }

        public Publisher()
        {
            Books = new Collection<Book>();
        }
    }
}
