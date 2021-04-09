using Models;
using MVCLessonEnd.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(string id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(string id);

    }
}
