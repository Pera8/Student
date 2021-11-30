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
    [Route("api/School")]
    public class SchoolController : Controller
    {
        private readonly SchoolService schoolService;

        public SchoolController(SchoolService schoolService)
        {
            this.schoolService = schoolService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllSchool()
        {
            return Ok(await schoolService.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult> AddSchool(SchoolDTO school)
        {
            return Ok(await schoolService.AddAsync(school));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<School>> GetSchoolById(int id)
        {
            return Ok(await schoolService.GetAsyncById(id));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteSchool(int id)
        {
            await schoolService.DeleteAsync(id);
            return Ok();
        }
    }
}
