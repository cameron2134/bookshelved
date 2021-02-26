using AutoMapper;
using Bookshelved.Core.DomainModels.Book;
using Bookshelved.Core.DTOs;
using Bookshelved.Core.DTOs.Book;

namespace Bookshelved.API.Mappings
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