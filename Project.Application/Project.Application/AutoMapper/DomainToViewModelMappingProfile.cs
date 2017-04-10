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
            CreateMap<SubCategoria, SubCategoriaViewModel>();
            CreateMap<Produto, ProdutoViewModel>();
        }

    }
}