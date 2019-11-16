using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Service;
using Domain;
using REST_Service.Model;
using REST_Service.Repository;

namespace REST_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _service;

        public StudentController()
        {
            _service = new StudentService();
        }
        
        [HttpGet]
        public ActionResult<List<Student>> GetAllStudents()
        {
            EntityMapper<Student, StudentModel> mapper = new EntityMapper<Student,StudentModel>();
            List<Student> prodList = _service.Get();
            List<StudentModel> students = new List<StudentModel>();
            foreach (var item in prodList )
            {
                students.Add(mapper.Translate(item));
            }

            return Ok(students);
        }

        [HttpPost("search")]
        public ActionResult<List<StudentModel>> SearchByLastNameOrName([FromBody]string query)
        {
            List<Student> list = _service.Search(query);
            return Ok(list);
        }

        [HttpGet("{id}")]
        public StudentModel GetStudent(int id)
        {
            EntityMapper<Student, StudentModel> mapper = new EntityMapper<Student, StudentModel>();
            Student dalStudent = _service.GetById(id);
            var students = mapper.Translate(dalStudent);
            return students;
        }

        [HttpPost]
        public bool InsertStudent(StudentModel Student)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapper<StudentModel, Student> mapper = new EntityMapper<StudentModel, Student>();
                var student = mapper.Translate(Student);
                _service.Insert(student);
                status = true;
            }

            return status;
        }

        [HttpPut]
        public bool UpdateStudent(StudentModel Student)
        {
            bool status = false;
            EntityMapper<StudentModel, Student> mapper = new EntityMapper<StudentModel, Student>();
            Student student = new Student();
            student = mapper.Translate(Student);
            _service.Update(student,student.StudentId);
            status = true;
            return status;
        }

        [HttpDelete("{id}")]
        public bool DeleteStudent(int id)
        {
            bool status = false;
            _service.Delete(id);
            status = true;
            return status;
        }
    }
}