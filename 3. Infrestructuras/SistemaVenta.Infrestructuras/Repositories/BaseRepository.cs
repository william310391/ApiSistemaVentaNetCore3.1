using Microsoft.EntityFrameworkCore;
using SistemaVenta.Infraestructura.Data;
using SistemaVenta.Core.Entities;
using SistemaVenta.Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaVenta.Core.Exceptions;

namespace SistemaVenta.Infraestructura.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {

        private readonly VentasContext _context;
        protected readonly DbSet<T> _entities;
        public BaseRepository(VentasContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public async Task<T> GetById(int Id)
        {    
            var ent = await _entities.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (ent != null){
                return ent;
            }
            else {
                throw new BusinessException("El Id del registro no existe");
            }
      
        }

        public async Task Add(T entity)
        {
           await _entities.AddAsync(entity);            
        }

        public void Update(T entity)
        {
            var ent = GetById(entity.Id);

            if (ent != null)
            {
                _entities.Update(entity);
            }
            else {
                throw new BusinessException("El Id del registro no existe");
            }        
        } 

        public async Task Delete(int Id)
        {
            T entity = await GetById(Id);
            if (entity != null)
            {
                _entities.Remove(entity);
            }
            else {
                throw new RespuestaException("El registro ya se encuentra eliminado");
            }
                    
        }    

    }


}
