using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Repository.Repository.IRepository;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class StudentService : IRepository<Student>
    {
        private readonly IRepository<Student> repositoryStudent;
        private readonly IRepository<School> repositorySchool;

        public StudentService(IRepository<Student> repositoryStudent, IRepository<School> repositorySchool)
        {
            this.repositoryStudent = repositoryStudent;
            this.repositorySchool = repositorySchool;
        }
        public async Task<Student> AddAsync(StudentDTO model)
        {
            if (model == null)
            {
                throw new Exception("Student can not be null");
            }

            var school = await repositorySchool.GetAsyncById(model.SchoolID);

            var studetDTO = new Student()
            {
                Id = model.Id,
                Name = model.Name,
                LastName = model.LastName,
                Address = model.Address,
                School = school,
            };

            if (school == null)
            {
                throw new Exception("School can not be null");
            }

            return await repositoryStudent.AddAsync(studetDTO);
        }

        public Task<Student> AddAsync(Student model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1)
            {
                throw new Exception("Student can not be null");
            }
            await repositoryStudent.DeleteAsync(id);
        }

        public async Task<DbSet<Student>> GetAll()
        {
            return await repositoryStudent.GetAll();
        }

        public async Task<Student> GetAsyncById(int id)
        {
            if (id < 1)
            {
                throw new Exception("Student id can not be null");
            }
            return await repositoryStudent.GetAsyncById(id);
        }
    }
}
