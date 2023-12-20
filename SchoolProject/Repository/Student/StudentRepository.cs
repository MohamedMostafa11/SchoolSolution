using SchoolProject.Context;
using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MyDbContext _myDbConnection;

        public StudentRepository(MyDbContext myDbContext)
        {
            _myDbConnection = myDbContext;
        }
        public List<Student> GetAllStudents()
        {
            try
            {
                List<Student> students = (from stdsObj in _myDbConnection.Students
                                          select stdsObj).ToList();
                return students;
            }
            catch (Exception ex)
            {
                
                return null;
            }
            
        }

        public void Create(Student student)
        {
            _myDbConnection.Students.Add(student);
            _myDbConnection.SaveChanges();
        }

        public void Delete(int id)
        {
            Student student = (from stdObj in _myDbConnection.Students
                               where stdObj.StudentId == id
                               select stdObj).FirstOrDefault();

            _myDbConnection.Students.Remove(student);
            _myDbConnection.SaveChanges();
        }

        public void Register(int studentId, int courseId)
        {

            _myDbConnection.StudentCourses.Add(new StudentCourse
            {
                CourseId = courseId,
                StudentId = studentId
            }) ;

            _myDbConnection.SaveChanges();
        }
    }
}
