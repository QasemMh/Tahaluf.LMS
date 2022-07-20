using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.LMS.Core.Data;
using Tahaluf.LMS.Core.DTO;
using Tahaluf.LMS.Core.Repository;
using Tahaluf.LMS.Core.Service;

namespace Tahaluf.LMS.Infra.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepository;
        public CourseService(ICourseRepository
        _courseRepository)
        {
            courseRepository = _courseRepository;
        }
        
        public bool Create(Course course)
        {
            return courseRepository.Create(course);
        }

        public bool Delete(int id)
        {
            return courseRepository.Delete(id);
        }

        public List<Course> GetByDateFrom(DateTime dateFrom)
        {
            return courseRepository.GetByDateFrom(dateFrom);
        }

        public List<Course> GetByDateTo(DateTime dateTo)
        {
            return courseRepository.GetByDateTo(dateTo);
        }

        public List<Course> GetCheapestCourse()
        {
            return courseRepository.GetCheapestCourse();
        }

        public List<Course> GetCoursesByName(string name)
        {
            return courseRepository.GetCoursesByName(name);
        }

        public List<Course> GetCoursesByPrice(double price)
        {
            return courseRepository.GetCoursesByPrice(price);
        }

        public List<CourseDto> GetSimpleCourses()
        {
            return courseRepository.GetSimpleCourses();
        }

        public List<Course> ReadAll()
        {
            return courseRepository.ReadAll();
        }

        public bool Update(Course course)
        {
            return courseRepository.Update(course);
        }
    }
}
