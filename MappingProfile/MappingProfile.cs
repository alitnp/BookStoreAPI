using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.Models;
using BookStore.Resources;

namespace BookStore.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to API
            CreateMap<Book, BookResource>();
            CreateMap<Publisher, PublisherResource>();
            CreateMap<Book, PublisherBookResource>();
            CreateMap<Genre, GenreResource>();

            //API to Domain
            CreateMap<SavePublisherResource, Publisher>();
            CreateMap<SaveBookResource, Book>();
        }
    }
}
