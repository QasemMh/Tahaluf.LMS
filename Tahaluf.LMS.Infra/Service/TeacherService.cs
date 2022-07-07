using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.LMS.Core.Data;
using Tahaluf.LMS.Core.Repository;
using Tahaluf.LMS.Core.Service;

namespace Tahaluf.LMS.Infra.Service
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        
        public bool Create(Teacher teacher)
        {
          return  _teacherRepository.Create(teacher);
        }

        public bool Delete(int id)
        {
            return _teacherRepository.Delete(id);
        }

        public List<Teacher> GetAll()
        {
            return _teacherRepository.GetAll();
        }

        public Teacher GetTeacherByEmail(string email)
        {
            return _teacherRepository.GetTeacherByEmail(email);
        }

        public Teacher GetTeacherById(int id)
        {
            return _teacherRepository.GetTeacherById(id);
        }

        public bool Update(Teacher teacher)
        {
            return _teacherRepository.Update(teacher);
        }
    }
}
