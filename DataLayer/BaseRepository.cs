using Microsoft.EntityFrameworkCore;
using Models;
using MVCLessonEnd.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private readonly AppContext _context;

        public BaseRepository(AppContext context)
        {
            this._context = context;
        }

        public async Task Delete(string id)
        {
            var employeeModel = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(employeeModel);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Get(string id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(m => m.ID == id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await this._context.Set<T>().ToListAsync();
        }

        public async Task Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}