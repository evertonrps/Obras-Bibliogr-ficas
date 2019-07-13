using ObrasBibliograficas.Domain;
using ObrasBibliograficas.Domain.Interfaces;
using ObrasBibliograficas.Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObrasBibliograficas.Repository.Repository
{

    public class AutorRepository : Repository<Autor>, IAutorRepository
    {
        public AutorRepository(ObrasBibliograficasContext context) : base(context)
        {

        }
    }
}
