using Microsoft.EntityFrameworkCore;
using Practical_20.Model.Data;
using Practical_20.Repository.Implementation;
using Practical_20.Repository.Interface;

namespace Practical_20.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IEmployeeRepo Employees { get; }

        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Employees = new EmployeeRepo(context);
        }
        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
