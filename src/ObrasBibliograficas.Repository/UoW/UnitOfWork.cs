using ObrasBibliograficas.Domain.Interfaces;
using ObrasBibliograficas.Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ObrasBibliograficas.Repository.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ObrasBibliograficasContext _context;

        public UnitOfWork(ObrasBibliograficasContext context)
        {
            _context = context;
        }

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
