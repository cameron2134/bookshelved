using AutoMapper;
using Bookshelved.Core.DomainModels.Book;
using Bookshelved.Core.DTOs;
using Bookshelved.Core.DTOs.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookshelved.Core.DomainModels.Account;
using Bookshelved.Core.DTOs.Account;

namespace Bookshelved.Services.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Book Schema Mappings

            CreateMap<Book, BookDTO>()
                .ReverseMap();

            CreateMap<Book, BookDetailsDTO>()
                .ReverseMap();

            CreateMap<Series, SeriesDTO>()
                .ReverseMap();

            CreateMap<Author, AuthorDTO>()
                .ReverseMap();

            CreateMap<Review, ReviewDTO>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.ApplicationUser))
                .ReverseMap();

            CreateMap<BookProgress, BookProgressDTO>()
                .ReverseMap();

            CreateMap<ReadingList, ReadingListDTO>()
                .ReverseMap();

            #endregion

            #region Account Schema Mappings
            CreateMap<ApplicationUser, ApplicationUserDTO>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.UserName))
                .ReverseMap();
            #endregion
        }
    }
}