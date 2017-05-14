using AutoMapper;
using Project.Application.ViewModels;
using Project.Domain.Entities;

namespace Project.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Categoria, CategoriaViewModel>();

            CreateMap<SubCategoria, SubCategoriaViewModel>()
                .ForMember(dest => dest.CategoriaViewModel, opt => opt.MapFrom(src => src.Categoria));

            CreateMap<Produto, ProdutoViewModel>()                
                .ForMember(dest => dest.SubCategoriaViewModel, opt => opt.MapFrom(src => src.SubCategoria))
                .ForMember(dest => dest.ProdutoImagemViewModels, opt => opt.MapFrom(src => src.ProdutoImagens));

            CreateMap<ProdutoImagem, ProdutoImagemViewModel>();
        }

    }
}