using Practical_20.Model.Entities;
using Practical_20.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Practical_20.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IUnitOfWork _uow;

    public EmployeeController(IUnitOfWork uow)
    {
        _uow = uow;
    }

    [HttpGet]
    public async Task<IEnumerable<Employee>> GetAllEmployees()
    {
        return await _uow.Employees.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<Employee> GetEmployeeById(int id)
    {
        return await _uow.Employees.GetById(id);
    }

    [HttpPost]
    public async Task CreateEmployee(Employee employee)
    {
        await _uow.Employees.Create(employee);
        await _uow.Save();
    }

    [HttpPut]
    public async Task UpdateEmployee(Employee employee)
    {
        await _uow.Employees.Update(employee);
        await _uow.Save();
    }

    [HttpDelete("{id}")]
    public async Task DeleteEmployee(int id)
    {
        await _uow.Employees.Delete(id);
        await _uow.Save();
    }

    [HttpGet("exception")]
    public IActionResult TestException()
    {
        throw new Exception("Exception for test");
    }
}