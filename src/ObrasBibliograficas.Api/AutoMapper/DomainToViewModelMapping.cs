using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ObrasBibliograficas.Api.ViewModels;
using ObrasBibliograficas.Domain;

namespace ObrasBibliograficas.Api.AutoMapper
{
    public class DomainToViewModelMapping : Profile
    {
        public DomainToViewModelMapping()
        {
            CreateMap<Autor, AutorViewModel>();
        }
    }
}
