using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lab11.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab11.Controllers
{
    public class StudentController : Controller
    {
        readonly Proxy.StudentProxy _proxy = new Proxy.StudentProxy();
        // GET
        public IActionResult Index()
        {
            var response = Task.Run(() => _proxy.GetStudentsAsync());
            return View((List<StudentModel>) response.Result.listado);
        }

        [HttpGet]
        public JsonResult GetStudents()
        {
            var response = Task.Run(() => _proxy.GetStudentsAsync());
            return Json(response.Result.listado);
        }

        [HttpPost]
        public JsonResult CreateStudent([FromBody] StudentModel student)
        {
            var response = Task.Run(() => _proxy.InsertAsync(student));
            return Json(response.Result.Exitoso);
        }

        [HttpPost]
        public JsonResult FilterByNameOrLastName([FromBody] string query)
        {
            var response = Task.Run(() => _proxy.SearchStudentsAsync(query));
            return Json(response.Result.listado);
        }

        [HttpPost]
        public JsonResult GetStudentById([FromBody] string id)
        {
            var response = Task.Run(() => _proxy.GetStudentByIdAsync(int.Parse(id)));
            return Json(response.Result.objeto);
        }

        [HttpPost]
        public JsonResult UpdateStudent([FromBody] StudentModel student)
        {
            var response = Task.Run(() => _proxy.UpdateStudentAsync(student));
            return Json(response.Result.Exitoso);
        }

        [HttpPost]
        public JsonResult DeleteStudent([FromBody] string id)
        {
            var response = Task.Run(() => _proxy.DeleteStudentAsync(int.Parse(id)));
            return Json(response.Result.Exitoso);
        }
    }
}