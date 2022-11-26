using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Resources
{
    public class BookResource : BaseResource
    {
        public PublisherResource Publisher { get; set; }
        public GenreResource Genre { get; set; }
    }
}
