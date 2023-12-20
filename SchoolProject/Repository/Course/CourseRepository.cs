using SchoolProject.Context;
using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Repository
{
    public class CourseRepository:ICourseRepository
    {
        private readonly MyDbContext _myDbContext;

        public CourseRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public void Create(Course course)
        {
            _myDbContext.Courses.Add(course);
            _myDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Course course = (from courseObj in _myDbContext.Courses
                               where courseObj.TeacherId == id
                               select courseObj).FirstOrDefault();
            _myDbContext.Courses.Remove(course);
            _myDbContext.SaveChanges();
        }

        public List<Course> GetAllCourses()
        {
            List<Course> course = (from courseObj in _myDbContext.Courses
                                      select courseObj).ToList();
            return course;
        }
    }
}
