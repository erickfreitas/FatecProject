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
                .ForMember(dest => dest.CategoriaViewModel, opt => opt.MapFrom(src => src.Categoria))
                .ForMember(dest => dest.SubCategoriaViewModel, opt => opt.MapFrom(src => src.SubCategoria))
                .ForMember(dest => dest.ProdutoImagemViewModels, opt => opt.MapFrom(src => src.ProdutoImagens))
                .ForMember(dest => dest.PerguntasViewModels, opt => opt.MapFrom(src => src.Perguntas));

            CreateMap<ProdutoImagem, ProdutoImagemViewModel>();

            CreateMap<Usuario, UsuarioViewModel>();

            CreateMap<Pergunta, PerguntaViewModel>();


            CreateMap<Resposta, RespostaViewModel>()
                .ForMember(dest => dest.PerguntaViewModel, opt => opt.MapFrom(src => src.Pergunta)); 

        }

    }
}