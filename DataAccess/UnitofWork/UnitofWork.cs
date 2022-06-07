using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.UnitofWork;
using DataAccess.Concrete.EntityFramework;

namespace DataAccess.UnitofWork
{
    public class UnitofWork : IUnitofWork
    {
        private readonly WebAPIDbContext _context;

        public UnitofWork(WebAPIDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
