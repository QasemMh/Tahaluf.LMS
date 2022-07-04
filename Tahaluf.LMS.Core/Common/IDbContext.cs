using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Tahaluf.LMS.Core.Common
{
    public interface IDbContext
    {
        DbConnection Connection { get; } 
    }
}
