using AutoMapper;
using BookRental.Dev.Application.Features.Book.Queries.GetBookById;
using BookRental.Dev.Domain.Entities;

namespace BookRental.Dev.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookByIdVm>();
        }
    }
}
