using System;
using System.Collections.Generic;
using System.Text;

namespace ObrasBibliograficas.Domain
{
    public abstract class Entity<T> where T : Entity<T>
    {
        public int Id { get; protected set; }
    }
}
