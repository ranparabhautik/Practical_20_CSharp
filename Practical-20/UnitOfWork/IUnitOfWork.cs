using Practical_20.Repository.Interface;

namespace Practical_20.UnitOfWork
{
    public interface IUnitOfWork
    {
        IEmployeeRepo Employees { get; }

        Task<int> Save();
    }
}
