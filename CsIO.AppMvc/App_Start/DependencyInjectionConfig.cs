using CsIO.Business.Models.Fornecedores.Interfaces.Repositories;
using CsIO.Business.Models.Fornecedores.Interfaces.Services;
using CsIO.Business.Models.Fornecedores.Services;
using CsIO.Business.Models.Produtos.Interfaces;
using CsIO.Business.Models.Produtos.Services;
using CsIO.Business.Notifications;
using CsIO.Infra.Data.Context;
using CsIO.Infra.Data.Repositories;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace CsIO.AppMvc.App_Start
{
    public class DependencyInjectionConfig
    {
        public static void RegisterDIContainer()
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        public static void InitializeContainer(Container container)
        {
            // Context
            container.Register<CsIoContext>(Lifestyle.Scoped);

            // Repositories
            container.Register<IProdutoRepository, ProdutoRepository>(Lifestyle.Scoped);
            container.Register<IFornecedorRepository, FornecedorRepository>(Lifestyle.Scoped);
            container.Register<IEnderecoRepository, EnderecoRepository>(Lifestyle.Scoped);

            // Services
            container.Register<IProdutoService, ProdutoService>(Lifestyle.Scoped);
            container.Register<IFornecedorService, FornecedorService>(Lifestyle.Scoped);

            // Notification
            container.Register<INotification, Notification>(Lifestyle.Scoped);

            // AutoMapper
            container.RegisterSingleton(() => AutoMapperConfig.GetMapperConfiguration().CreateMapper(container.GetInstance));
        }
    }
}