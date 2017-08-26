using AutoMapper;
using Project.Application.ViewModels;
using Project.Domain.Entities;

namespace Project.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            #region CategoriaMaps
            CreateMap<Categoria, CategoriaViewModel>();
            #endregion

            #region SubCategoriaMaps
            CreateMap<SubCategoria, SubCategoriaViewModel>()
                .ForMember(dest => dest.CategoriaViewModel, opt => opt.MapFrom(src => src.Categoria));
            #endregion

            #region ProdutoMaps
            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(dest => dest.CategoriaViewModel, opt => opt.MapFrom(src => src.Categoria))
                .ForMember(dest => dest.SubCategoriaViewModel, opt => opt.MapFrom(src => src.SubCategoria))
                .ForMember(dest => dest.ProdutoImagemViewModels, opt => opt.MapFrom(src => src.ProdutoImagens));
            #endregion

            #region ProdutoImagemMaps
            CreateMap<ProdutoImagem, ProdutoImagemViewModel>();
            #endregion

            #region UsuarioMaps
            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<Usuario, UsuarioInformacaoViewModel>()
                .ForMember(dest => dest.Cep, opt => opt.MapFrom(src => src.Endereco.Cep))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Endereco.Estado))
                .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.Endereco.Cidade))
                .ForMember(dest => dest.Bairro, opt => opt.MapFrom(src => src.Endereco.Bairro))
                .ForMember(dest => dest.Logradouro, opt => opt.MapFrom(src => src.Endereco.Logradouro))
                .ForMember(dest => dest.Complemento, opt => opt.MapFrom(src => src.Endereco.Complemento))
                .ForMember(dest => dest.Numero, opt => opt.MapFrom(src => src.Endereco.Numero));
            #endregion

            #region PerguntaMaps
            CreateMap<Pergunta, PerguntaViewModel>();
            CreateMap<Pergunta, PerguntaUsuarioViewModel>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Usuario.Nome))
                .ForMember(dest => dest.Sobrenome, opt => opt.MapFrom(src => src.Usuario.Sobrenome))
                .ForMember(dest => dest.ImagemCaminho, opt => opt.MapFrom(src => src.Usuario.ImagemCaminho));
            #endregion

            #region RespostaMaps
            CreateMap<Resposta, RespostaViewModel>();
        }
    }
}