using Practical_20.Model.Data;
using Practical_20.Model.Entities;
using Practical_20.Repository.Interface;

namespace Practical_20.Repository.Implementation
{
    public class EmployeeRepo:GenericRepo<Employee>,IEmployeeRepo
    {
        public EmployeeRepo(AppDbContext context):base(context)
        {
            
        }
    }
}
