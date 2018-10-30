using System;
using System.Collections.Generic;
using System.Text;

namespace AppVendas.Domain
{
    public interface IRepository<TEntity>
    {
        TEntity GetById(int id);
        void Save(TEntity entity);
    }
}
