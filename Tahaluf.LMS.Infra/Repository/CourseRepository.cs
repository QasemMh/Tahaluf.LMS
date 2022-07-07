﻿using System;
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
            parameters.Add("@Name", course.Name, dbType: DbType.String);
            parameters.Add("@Price", course.Price, dbType: DbType.Double);
            parameters.Add("@StartDate", course.StartDate, dbType: DbType.Date);
            parameters.Add("@EndDate", course.EndDate, dbType: DbType.Date);

            var result = _context.Connection
                  .ExecuteAsync("Course_Package.CreateCourse", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Course> ReadAll()
        {
            var result = _context.Connection
                .Query<Course>("Course_Package.GetCreateCourses", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public bool Update(Course course)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", course.Id, dbType: DbType.Int32);
            parameters.Add("@Name", course.Name, dbType: DbType.String);
            parameters.Add("@Price", course.Price, dbType: DbType.Double);
            parameters.Add("@StartDate", course.StartDate, dbType: DbType.Date);
            parameters.Add("@EndDate", course.EndDate, dbType: DbType.Date);

            var result = _context.Connection
                  .ExecuteAsync("Course_Package.UpdateCourse", parameters, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool Delete(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id, dbType: DbType.Int32);
            var result = _context.Connection
                  .ExecuteAsync("Course_Package.DeleteCourse",
                                parameters,
                                commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Course> GetCoursesByName(string name)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", name, dbType: DbType.String);
            var result = _context.Connection
                  .Query<Course>("Course_Package.GetCoursesByName",
                                 parameters,
                                 commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Course> GetCoursesByPrice(double price)
        {   
            var parameters = new DynamicParameters();
            parameters.Add("@Price", price, dbType: DbType.Double);
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
            parameters.Add("@DateFrom", dateFrom, dbType: DbType.Date);
            var result = _context.Connection
                .Query<Course>("Course_Package.GetByDateFrom",
                                 parameters,
                                 commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Course> GetByDateTo(DateTime dateTo)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@DateTo", dateTo, dbType: DbType.Date);
            var result = _context.Connection
                .Query<Course>("Course_Package.GetByDateTo",
                                parameters,
                                commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
