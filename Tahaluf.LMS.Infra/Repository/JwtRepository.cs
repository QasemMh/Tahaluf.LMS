using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Dapper;
using Tahaluf.LMS.Core.Common;
using Tahaluf.LMS.Core.Data;
using Tahaluf.LMS.Core.Repository;

namespace Tahaluf.LMS.Infra.Repository
{
    public class JwtRepository : IJwtRepository
    {
        private readonly IDbContext dBContext;
        public JwtRepository(IDbContext _dBContext)
        {
            dBContext = _dBContext;
        }
        
        public Login Auth(Login login)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@user_name", login.Username, dbType: DbType.String);
            parameters.Add("@pass", login.Password, dbType: DbType.String);
            IEnumerable<Login> result =
            dBContext.Connection.Query<Login>("UserLogin",
                                              parameters,
                                              commandType: CommandType.StoredProcedure);

            
            var loginResult = result.FirstOrDefault();
            //login.Role = new Role
            //{
            //    Id = loginResult.RoleId,
            //    Name = dBContext.Connection.Query<Role>
            //    ("select name from Role where id="+loginResult.RoleId).FirstOrDefault().Name
            // };

            return loginResult;
        }
    }
}
