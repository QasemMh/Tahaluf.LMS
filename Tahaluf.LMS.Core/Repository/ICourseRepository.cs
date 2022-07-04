using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.LMS.Core.Data;

namespace Tahaluf.LMS.Core.Repository
{
    public interface ICourseRepository
    {
        bool Create(Course course);
        List<Course> ReadAll();
        bool Update(Course course);
        bool Delete(int id);
    }
}
