using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Project.Application.AppServices;
using Project.Application.Interfaces;
using Project.Domain.Interfaces.Repositories;
using Project.Domain.Interfaces.Services;
using Project.Domain.Services;
using Project.Infra.CrossCutting.Identity.Configuration;
using Project.Infra.CrossCutting.Identity.Context;
using Project.Infra.CrossCutting.Identity.Model;
using Project.Infra.Data.Repositories;
using SimpleInjector;

namespace Project.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe
            // Lifestyle.Scoped => Uma instancia unica para o request

            #region IdentityDependences
            //Identity
            container.Register<IdentityContext>(Lifestyle.Scoped);
            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new IdentityContext()), Lifestyle.Scoped);
            container.Register<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>(new IdentityContext()), Lifestyle.Scoped);
            container.Register<ApplicationRoleManager>(Lifestyle.Scoped);
            container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            container.Register<ApplicationSignInManager>(Lifestyle.Scoped);
            #endregion

            #region AppDependences
            container.Register(typeof(IAppServiceBase<>), typeof(AppServiceBase<>), Lifestyle.Scoped);
            container.Register<ICategoriaAppService, CategoriaAppService>(Lifestyle.Scoped);
            container.Register<ISubCategoriaAppService, SubCategoriaAppService>(Lifestyle.Scoped);
            container.Register<IProdutoAppService, ProdutoAppService>(Lifestyle.Scoped);
            container.Register<IProdutoImagemAppService, ProdutoImagemAppService>(Lifestyle.Scoped);
            container.Register<IUsuarioAppService, UsuarioAppService>(Lifestyle.Scoped);
            container.Register<IPerguntaAppService, PerguntaAppService>(Lifestyle.Scoped);
            container.Register<IRespostaAppService, RespostaAppService>(Lifestyle.Scoped);
            #endregion

            #region DomainDependences
            container.Register(typeof(IServiceBase<>), typeof(ServiceBase<>), Lifestyle.Scoped);
            container.Register<ICategoriaService, CategoriaService>(Lifestyle.Scoped);
            container.Register<ISubCategoriaService, SubCategoriaService>(Lifestyle.Scoped);
            container.Register<IProdutoService, ProdutoService>(Lifestyle.Scoped);
            container.Register<IProdutoImagemService, ProdutoImagemService>(Lifestyle.Scoped);
            container.Register<IUsuarioService, UsuarioService>(Lifestyle.Scoped);
            container.Register<IPerguntaService, PerguntaService>(Lifestyle.Scoped);
            container.Register<IRespostaService, RespostaService>(Lifestyle.Scoped);
            #endregion

            #region DataDependences
            container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>), Lifestyle.Scoped);
            container.Register<ICategoriaRepository, CategoriaRepository>(Lifestyle.Scoped);
            container.Register<ISubCategoriaRepository, SubCategoriaRepository>(Lifestyle.Scoped);
            container.Register<IProdutoRepository, ProdutoRepository>(Lifestyle.Scoped);
            container.Register<IProdutoImagemRepository, ProdutoImagemRepository>(Lifestyle.Scoped);
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
            container.Register<IPerguntaRepository, PerguntaRepository>(Lifestyle.Scoped);
            container.Register<IRespostaRepository, RespostaRepository>(Lifestyle.Scoped);
            #endregion
        }
    }
}
