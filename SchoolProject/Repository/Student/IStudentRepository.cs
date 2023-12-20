using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Repository
{
    public interface IStudentRepository
    {
        public List<Student> GetAllStudents();
        public void Create(Student student);

        public void Delete(int id);

        public void Register(int studentId, int courseId);

    }
}
