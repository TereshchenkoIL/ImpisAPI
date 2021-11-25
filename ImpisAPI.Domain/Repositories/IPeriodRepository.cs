using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImpisAPI.Domain.Entities;

namespace ImpisAPI.Domain.Repositories
{
    public interface IPeriodRepository
    {
        Task<IEnumerable<Period>> GetAllAsync();
        void Create(Period period);
        void Update(Period period); 
        void Delete(Period period);
    }
}