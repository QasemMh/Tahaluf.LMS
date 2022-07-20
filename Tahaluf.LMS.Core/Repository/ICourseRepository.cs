﻿using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.LMS.Core.Data;
using Tahaluf.LMS.Core.DTO;

namespace Tahaluf.LMS.Core.Repository
{
    public interface ICourseRepository
    {
        bool Create(Course course);
        List<Course> ReadAll();
        bool Update(Course course);
        bool Delete(int id);
        List<Course> GetCoursesByName(string name);
        List<Course> GetCoursesByPrice(double price);
        List<Course> GetCheapestCourse();
        List<Course> GetByDateFrom(DateTime dateFrom);
        List<Course> GetByDateTo(DateTime dateTo);
        
        List<CourseDto> GetSimpleCourses();



    }
}
