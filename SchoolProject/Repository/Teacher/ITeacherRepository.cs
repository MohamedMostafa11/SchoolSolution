using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Repository
{
    public interface ITeacherRepository
    {
        public List<Teacher> GetAllTeachers();
        public void Create(Teacher teacher);

        public void Delete(int id);
    }
}
