using AutoMapper;
using Bookshelved.Core.DomainModels.Book;
using Bookshelved.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelved.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDTO>()
                .ReverseMap();
        }
    }
}