using AutoMapper;
using Project.Application.ViewModels;
using Project.Domain.Entities;

namespace Project.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CategoriaViewModel, Categoria>();
            CreateMap<SubCategoriaViewModel, SubCategoria>();
            CreateMap<ProdutoViewModel, Produto>();
            CreateMap<ProdutoImagemViewModel, ProdutoImagem>();
            CreateMap<UsuarioViewModel, Usuario>();
            CreateMap<UsuarioInformacaoViewModel, Usuario>();                
            CreateMap<UsuarioInformacaoViewModel, Endereco>()
                .ForMember(dest => dest.Cep, opt => opt.MapFrom(src => src.Cep))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado))
                .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.Cidade))
                .ForMember(dest => dest.Bairro, opt => opt.MapFrom(src => src.Bairro))
                .ForMember(dest => dest.Logradouro, opt => opt.MapFrom(src => src.Logradouro))
                .ForMember(dest => dest.Complemento, opt => opt.MapFrom(src => src.Complemento))
                .ForMember(dest => dest.Numero, opt => opt.MapFrom(src => src.Numero)); ;
            CreateMap<PerguntaViewModel, Pergunta>();
            CreateMap<RespostaViewModel, Resposta>();
        }
    }
}