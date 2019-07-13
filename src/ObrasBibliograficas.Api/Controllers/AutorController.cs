using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObrasBibliograficas.Api.ViewModels;
using ObrasBibliograficas.Domain;
using ObrasBibliograficas.Domain.Interfaces;

namespace ObrasBibliograficas.Api.Controllers
{
    [Route("api/autores")]
    [ApiController]
    public class AutorController : Controller
    {
        private readonly IAutorRepository _autorRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public AutorController(IAutorRepository autorRepository, IMapper mapper, IUnitOfWork uow)
        {
            _autorRepository = autorRepository;
            _mapper = mapper;
            _uow = uow;
        }
   
        [HttpPost]
        public IEnumerable<AutorViewModel> Post([FromBody] IEnumerable<AutorViewModel> value)
        {
            try
            {
                var dev = _mapper.Map<IEnumerable<Autor>>(value);

                    var added = _autorRepository.Add(dev);
                    if (_uow.Commit().Result > 0)
                    {
                        var ret = _mapper.Map<IEnumerable<AutorViewModel>>(added);                        
                        return ret;
                    }
                    else
                    {
                        throw new Exception("Falha ao inserir");
                    }

            }
            catch (Exception ex)
            {
                return new List<AutorViewModel>();
            }
        }

    }
}