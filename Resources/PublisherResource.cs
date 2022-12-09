using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Resources
{
    public class PublisherResource : BaseResource
    {
        public ICollection<PublisherBookResource> Books { get; set; }

        public PublisherResource()
        {
            Books = new Collection<PublisherBookResource>();
        }
    }
}
