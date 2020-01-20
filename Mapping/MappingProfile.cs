using AutoMapper;
using BookCatalogue.Controllers.Resources;
using BookCatalogue.Models;

namespace BookCatalogue.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookResource>()
                .ForMember(br => br.Author, opt => opt.MapFrom(b => new AuthorResource { Id = b.Author.Id, Name = b.Author.Name }))
                .ForMember(br => br.Category, opt => opt.MapFrom(b => new BookCategoryResource { Id = b.Category.Id, Name = b.Category.Name }));

            CreateMap<BookResource, Book>()
                .ForMember(b => b.Id, opt => opt.Ignore())
                .ForMember(b => b.Author, opt => opt.Ignore())
                .ForMember(b => b.Category, opt => opt.Ignore())
                .ForMember(b => b.AuthorId, opt => opt.MapFrom(br => br.Author.Id))
                .ForMember(b => b.CategoryId, opt => opt.MapFrom(br => br.Category.Id));
        }
    }
}