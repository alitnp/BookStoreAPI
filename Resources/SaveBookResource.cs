using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Resources
{
    public class SaveBookResource : BaseResource
    {
        public int PublisherId { get; set; }
        public int GenreId { get; set; }
    }
}
