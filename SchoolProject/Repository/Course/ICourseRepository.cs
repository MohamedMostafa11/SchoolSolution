using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Repository
{
    public interface ICourseRepository
    {
        public List<Course> GetAllCourses();
        public void Create(Course course);

        public void Delete(int id);
    }
}
