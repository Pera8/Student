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
    public class SchoolService : IRepository<School>
    {
        private readonly IRepository<School> repositorySchool;

        public SchoolService(IRepository<School> repositorySchool)
        {
            this.repositorySchool = repositorySchool;
        }
        public async Task<School> AddAsync(SchoolDTO model)
        {
            if (model == null)
            {
                throw new Exception("School can not be null");
            }

            var schoolDto = new School()
            {
                Id = model.Id,
                Name = model.Name,
                
            };

            return await repositorySchool.AddAsync(schoolDto);
        }

        public Task<School> AddAsync(School model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1)
            {
                throw new Exception("Id can not be null");
            }
            await repositorySchool.DeleteAsync(id);
        }

        public async Task<DbSet<School>> GetAll()
        {
            return await repositorySchool.GetAll();
        }

        public async Task<School> GetAsyncById(int id)
        {
            if (id < 1)
            {
                throw new Exception("id can not be null");
            }
            return await repositorySchool.GetAsyncById(id);
        }
    }
}
