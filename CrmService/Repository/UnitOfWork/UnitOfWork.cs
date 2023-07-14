using Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Commit()
        {
            _dataContext.SaveChanges();
        }
        public async Task CommitAsync()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}
