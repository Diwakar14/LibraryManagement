using AutoMapper;
using LibraryManagement.Dtos;
using LibraryManagement.Dtos.Book;
using LibraryManagement.Dtos.Issuer;
using LibraryManagement.Models;

namespace LibraryManagement.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>()
                .ReverseMap();

            CreateMap<CreateBookDto, Book>()
                .ReverseMap();

            CreateMap<Issuer, IssuerDto>()
                .ReverseMap();

            CreateMap<Issuer, CreateIssuerDto>()
                .ReverseMap();

            CreateMap<PagedResponse<Book>, PagedResponseDto<BookDto>>()
                .ReverseMap();
                
        }
    }
}
