using AutoMapper;
using Bookshelved.Core.DomainModels.Book;
using Bookshelved.Core.DTOs;
using Bookshelved.Core.DTOs.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelved.Services.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDTO>()
                .ReverseMap();

            CreateMap<Book, BookDetailsDTO>()
                .ReverseMap();

            CreateMap<Series, SeriesDTO>()
                .ReverseMap();

            CreateMap<Author, AuthorDTO>()
                .ReverseMap();
        }
    }
}