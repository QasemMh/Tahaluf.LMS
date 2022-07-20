using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using Tahaluf.LMS.Core.Common;
using Tahaluf.LMS.Core.Repository;

namespace Tahaluf.LMS.Infra.Repository
{
    public class GenericRepository<TModel> : IGenericRepository<TModel>
    {
        public T GenericCrud<T, TI>(TModel model)
        {
            throw new NotImplementedException();
        }
    }




}
