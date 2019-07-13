using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ObrasBibliograficas.Domain.Interfaces;
using ObrasBibliograficas.Repository.Context;
using ObrasBibliograficas.Repository.Repository;
using ObrasBibliograficas.Repository.UoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObrasBibliograficas.Ioc
{
    public static class BootStrapper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            services.AddScoped<ObrasBibliograficasContext>();

            services.AddScoped(typeof(IAutorRepository), typeof(AutorRepository));

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        }
    }
}
