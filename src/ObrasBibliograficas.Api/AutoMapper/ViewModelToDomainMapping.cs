using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ObrasBibliograficas.Api.ViewModels;
using ObrasBibliograficas.Domain;

namespace ObrasBibliograficas.Api.AutoMapper
{
    public class ViewModelToDomainMapping: Profile
    {
        public ViewModelToDomainMapping()
        {
            CreateMap<AutorViewModel, Autor>();
        }
    }
}
