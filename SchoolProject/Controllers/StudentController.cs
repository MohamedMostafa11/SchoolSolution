using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models;
using SchoolProject.Models.ViewModels;
using SchoolProject.Repository;

namespace SchoolProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IHostingEnvironment _environemt;

        public StudentController(IStudentRepository studentRepository,ICourseRepository courseRepository,
            IHostingEnvironment environment)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _environemt = environment;


        }
        //List of students
        [HttpGet]
        public ActionResult Index()
        {
            //viewbag , viewdata , tempdata

            ViewBag.username = "mustafa";
            ViewData["Message"] = "message";

            List<Student> stdLst = _studentRepository.GetAllStudents();
            return View(stdLst);
        }

        // Render The creation view
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student,IFormFile StudentPhoto)
        {
            var wwrootPath = _environemt.WebRootPath + "/StudentPictures/";

            Guid guid  = Guid.NewGuid();

            string fullPath = System.IO.Path.Combine(wwrootPath, guid + StudentPhoto.FileName);

            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                StudentPhoto.CopyTo(fileStream);
            };

            student.PhotoName = guid + StudentPhoto.FileName;
            _studentRepository.Create(student);
            List<Student> stdLst = _studentRepository.GetAllStudents();
            return View("Index", stdLst);
        }

        public ViewResult Delete(int id)
        {
            _studentRepository.Delete(id);
            List<Student> stdLst = _studentRepository.GetAllStudents();
            return View("Index", stdLst);
        }

        [HttpGet]
        public ActionResult Register()
        {
            if(TempData["test"] != null)
            {
                int value = (int)TempData["test"];
            }
           
            StudentCourseVM data = new StudentCourseVM();
            data.Courses = _courseRepository.GetAllCourses();
            data.Students = _studentRepository.GetAllStudents();
            return View(data);
        }

        [HttpPost]
        public ActionResult Register(int studentId , int courseId)
        {
            TempData["test"] = 10;
            _studentRepository.Register(studentId, courseId);
            return RedirectToAction("Register");
        }
    }
}
