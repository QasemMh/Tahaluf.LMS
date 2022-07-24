using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.LMS.Core.Data;

namespace Tahaluf.LMS.Core.Service
{
    public interface IJwtService
    {
        string Auth(Login login);
    }
}
