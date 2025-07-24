using Microsoft.EntityFrameworkCore;
using MyApp.Application.Interfaces;
using MyApp.Domain.Entities;
using MyApp.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Persistence.Repositories
{
    public class Repository<T>(MyAppDbContext context) : IRepository<T> where T : class
    {
        public async Task CreateAsync(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
        }

        public Task<List<T>> GetAllAsync()
        {
            return context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            if (entity is Content content)
            {
                content.IsDeleted = true;
                context.Set<T>().Update(entity);
            }
            else
            {
                context.Set<T>().Remove(entity);
            }

            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }
    }

}
