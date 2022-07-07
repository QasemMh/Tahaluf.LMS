using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.LMS.Core.Data;

namespace Tahaluf.LMS.Core.Repository
{
    public interface ITeacherRepository
    {
        public List<Teacher> GetAll();
        bool Create(Teacher teacher);
        bool Update(Teacher teacher);
        bool Delete(int id);
        Teacher GetTeacherById(int id);
        Teacher GetTeacherByEmail(string email);
    }
}
