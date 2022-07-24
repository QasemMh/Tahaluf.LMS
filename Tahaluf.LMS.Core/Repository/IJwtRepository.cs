using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.LMS.Core.Data;

namespace Tahaluf.LMS.Core.Repository
{
    public interface IJwtRepository
    {
        public Login Auth(Login login);
    }
}
