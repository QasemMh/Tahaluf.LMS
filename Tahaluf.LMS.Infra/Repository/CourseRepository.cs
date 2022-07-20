using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using Tahaluf.LMS.Core.Common;
using Tahaluf.LMS.Core.Data;
using Tahaluf.LMS.Core.DTO;
using Tahaluf.LMS.Core.Repository;

namespace Tahaluf.LMS.Infra.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IDbContext _context;

        public CourseRepository(IDbContext context)
        {
            _context = context;
        }

        public bool Create(Course course)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@cname", course.Name, dbType: DbType.String);
            parameters.Add("@cprice", course.Price, dbType: DbType.Double);
            parameters.Add("@sDate", course.StartDate, dbType: DbType.Date);
            parameters.Add("@eDate", course.EndDate, dbType: DbType.Date);

            var result = _context.Connection
                  .ExecuteAsync("Course_Package.CreateCourse",
                                parameters,
                                commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Course> ReadAll()
        {
            var result = _context.Connection
                .Query<Course>("Course_Package.GetAllCourses",
                               commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public bool Update(Course course)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@cId", course.Id, dbType: DbType.Int32);
            parameters.Add("@cname", course.Name, dbType: DbType.String);
            parameters.Add("@cprice", course.Price, dbType: DbType.Double);
            parameters.Add("@sDate", course.StartDate, dbType: DbType.Date);
            parameters.Add("@eDate", course.EndDate, dbType: DbType.Date);

            var result = _context.Connection
                  .ExecuteAsync("Course_Package.UpdateCourse", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool Delete(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@cid", id, dbType: DbType.Int32);
            var result = _context.Connection
                  .ExecuteAsync("Course_Package.DeleteCourse",
                                parameters,
                                commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Course> GetCoursesByName(string name)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@cname", name, dbType: DbType.String);
            var result = _context.Connection
                  .Query<Course>("Course_Package.GetCoursesByName",
                                 parameters,
                                 commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Course> GetCoursesByPrice(double price)
        {   
            var parameters = new DynamicParameters();
            parameters.Add("@cprice", price, dbType: DbType.Double);
            var result = _context.Connection
                  .Query<Course>("Course_Package.GetCoursesByPrice",
                                 parameters,
                                 commandType: CommandType.StoredProcedure);
            return result.ToList();
        }   

        public List<Course> GetCheapestCourse()
        {
            var result = _context.Connection
               .Query<Course>("Course_Package.GetCheapestCourse",
                               commandType: CommandType.StoredProcedure);
            return result.ToList(); 
        }

        public List<Course> GetByDateFrom(DateTime dateFrom)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@sdate", dateFrom, dbType: DbType.Date);
            var result = _context.Connection
                .Query<Course>("Course_Package.GetByDateFrom",
                                 parameters,
                                 commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Course> GetByDateTo(DateTime dateTo)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@edate", dateTo, dbType: DbType.Date);
            var result = _context.Connection
                .Query<Course>("Course_Package.GetByDateTo",
                                parameters,
                                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<CourseDto> GetSimpleCourses()
        {

            var result = _context.Connection
                .Query<CourseDto>("Course_Package.GetAllCourses",
                               commandType: CommandType.StoredProcedure);

            return result.ToList();

        }
    }
}
