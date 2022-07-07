using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using Tahaluf.LMS.Core.Common;
using Tahaluf.LMS.Core.Data;
using Tahaluf.LMS.Core.Repository;

namespace Tahaluf.LMS.Infra.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly IDbContext _context;

        public TeacherRepository(IDbContext context)
        {
            _context = context;
        }

        public bool Create(Teacher teacher)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FirstName", teacher.FirstName, dbType: DbType.String);
            parameters.Add("@MidName", teacher.MidName, dbType: DbType.String);
            parameters.Add("@LastName", teacher.LastName, dbType: DbType.String);
            parameters.Add("@Salary", teacher.Salary, dbType: DbType.Double);
            parameters.Add("@LoginId", teacher.LoginId, dbType: DbType.Int32);
            parameters.Add("@BirthDate", teacher.BirthDate, dbType: DbType.Date);

            var result = _context.Connection
                  .ExecuteAsync("Teacher_Package.CreateTeacher",
                                parameters,
                                commandType: CommandType.StoredProcedure);
            return true;
        }


        public bool Update(Teacher teacher)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FirstName", teacher.FirstName, dbType: DbType.String);
            parameters.Add("@MidName", teacher.MidName, dbType: DbType.String);
            parameters.Add("@LastName", teacher.LastName, dbType: DbType.String);
            parameters.Add("@Salary", teacher.Salary, dbType: DbType.Double);
            parameters.Add("@LoginId", teacher.LoginId, dbType: DbType.Int32);
            parameters.Add("@BirthDate", teacher.BirthDate, dbType: DbType.Date);
            parameters.Add("@Id", teacher.Id, dbType: DbType.Int32);
            var result = _context.Connection
                  .ExecuteAsync("Teacher_Package.UpdateTeacher",
                                parameters,
                                commandType: CommandType.StoredProcedure);
            return true;
        }
        
        public List<Teacher> GetAll()
        {
             var result = _context.Connection
                      .QueryAsync<Teacher>("Teacher_Package.GetAllTeachers",
                                      commandType: CommandType.StoredProcedure);
            return result.Result.ToList();
        }

        public Teacher GetTeacherById(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id, dbType: DbType.Int32);
            var result = _context.Connection
                .QueryAsync<Teacher>("Teacher_Package.GetTeacherById",
                              parameters,
                              commandType: CommandType.StoredProcedure);
            return result.Result.FirstOrDefault();
        }

        public bool Delete(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id, dbType: DbType.Int32);
            var result = _context.Connection
                .ExecuteAsync("Teacher_Package.DeleteTeacher",
                              parameters,
                              commandType: CommandType.StoredProcedure);
            return true;
        }

        public Teacher GetTeacherByEmail(string email)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Email", email, dbType: DbType.String);
            var result = _context.Connection
                .QueryAsync<Teacher>("Teacher_Package.GetTeacherByEmail",
                              parameters,
                              commandType: CommandType.StoredProcedure);
            return result.Result.FirstOrDefault();
        }
    }
}
