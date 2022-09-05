using SistemaVenta.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.Infraestructura.Interfaces
{
    public interface IBaseRepository<T> where T: BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(int Id);
        Task Add(T entity);
        void Update(T entity);
        Task Delete(int Id);
    }
}
