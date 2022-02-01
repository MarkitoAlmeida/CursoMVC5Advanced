using AutoMapper;
using CsIO.AppMvc.ViewModels;
using CsIO.Business.Models.Fornecedores;
using CsIO.Business.Models.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace CsIO.AppMvc.App_Start
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration GetMapperConfiguration()
        {
            // Uso de reflection para carregar todas as classes do tipo Profile
            // no momento que subir a aplicação. Como é feito apenas uma vez e
            // ao iniciar a app, não corre-se o risco de ter problemas de performance
            var profiles = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => typeof(Profile).IsAssignableFrom(x));

            return new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                    cfg.AddProfile(Activator.CreateInstance(profile) as Profile);
            });
        }
    }

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
        }
    }
}