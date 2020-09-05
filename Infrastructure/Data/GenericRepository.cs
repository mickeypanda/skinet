using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        public Task<IReadOnlyList<T>> GetAllListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
