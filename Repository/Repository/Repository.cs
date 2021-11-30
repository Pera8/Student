using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using Repository.Repository.IRepository;
using System;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class Repository<TModel> : IRepository<TModel> where TModel: class, IBaseModel
    {
        private readonly AppDBContext appDBContext;

        public Repository (AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public async Task<TModel> AddAsync(TModel model)
        {
            if (model == null)
            {
                throw new Exception("entity can not be null");
            }
            await appDBContext.AddAsync(model);
            await appDBContext.SaveChangesAsync();
            return model;
        }

        public async Task DeleteAsync(int id)
        {
            var result = await appDBContext.Set<TModel>().FirstOrDefaultAsync(e => e.Id == id);
            if (result != null)
            {
                appDBContext.Remove(result);
                await appDBContext.SaveChangesAsync();
            }
        }

        //public async Task DeleteAsyncWithRKey(int id)
        //{
        //    var result = await appDBContext.Set<TModel>().FirstOrDefaultAsync(e => e.Id == id).Include(e=>e.Student);
        //    if (result != null)
        //    {
        //        appDBContext.Remove(result);
        //        await appDBContext.SaveChangesAsync();
        //    }
        //}

        public async Task<DbSet<TModel>> GetAll()
        {
            return  appDBContext.Set<TModel>();
        }

        public async Task<TModel> GetAsyncById(int id)
        {
            return await appDBContext.Set<TModel>().FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
