using System;
using System.Collections.Generic;
using System.Text;

namespace Tahaluf.LMS.Core.Repository
{
    public interface IGenericRepository<TModel>
    {
        public T GenericCrud<T, TI>(TModel model); 

    }
}
