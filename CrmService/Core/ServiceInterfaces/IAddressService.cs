using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.ServiceInterfaces
{
    public interface IAddressService
    {
        Task<IEnumerable<Address>> GetAllAsync();
        Task<Address> GetByIdAsync(int id);
        Task AddAsync(Address address);
        IQueryable<Address> Where(Expression<Func<Address, bool>> expression);
        Task UpdateAsync(int id, Address address);
        Task DeleteAsync(int id);
    }
}
