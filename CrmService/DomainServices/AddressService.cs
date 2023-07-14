using Core.Entities;
using Core.GenericRepository;
using Core.ServiceInterfaces;
using Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices
{
    public class AddressService : IAddressService
    {
        private readonly IGenericRepository<Address> _repository;

        public AddressService(IGenericRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task AddAsync(Address address)
        {
            await _repository.AddAsync(address);
        }

        public async Task DeleteAsync(int id)
        {
            var address = await _repository.GetByIdAsync(id);
            _repository.Delete(address);
        }

        public async Task<IEnumerable<Address>> GetAllAsync()
        {
            var addresses = await _repository.GetAllAsync();
            return addresses.ToList();
        }

        public async Task<Address> GetByIdAsync(int id)
        {
            var address = await _repository.GetByIdAsync(id);
            return address;
        }

        public async Task UpdateAsync(int id, Address address)
        {
            var addressDb = await _repository.GetByIdAsync(id);
            if (addressDb != null)
            {
                addressDb.Description = address.Description;
                addressDb.City = address.City;
                addressDb.Country = address.Country;
                addressDb.PostCode = address.PostCode;
                addressDb.SchoolId = address.SchoolId;
                _repository.Update(addressDb);
            }
            else
            {
                throw new Exception("Can not found an entity by entered id .");
            }
        }

        public IQueryable<Address> Where(Expression<Func<Address, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}

