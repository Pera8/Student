using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Service;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApplication.Controllers
{
    [Route("api/Student")]
    public class StudentController : Controller
    {
        private readonly StudentService studentService;

        public StudentController(StudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllStudent()
        {
            return Ok(await studentService.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult> AddStudent(StudentDTO student)
        {
            return Ok(await studentService.AddAsync(student));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            await studentService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            await studentService.GetAsyncById(id);
            return Ok();
        }
    }
}
