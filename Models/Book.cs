using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    [Table("Books")]
    public class Book : BaseModel
    {
        public int PublisherId { get; set; }
        public int GenreId { get; set; }
        public Publisher Publisher { get; set; }
        public Genre Genre { get; set; }
    }
}
