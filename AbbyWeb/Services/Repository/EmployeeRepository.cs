using AbbyWeb.Data;
using AbbyWeb.Models;
using AbbyWeb.Services.Repository.IRepository;
using System;
using System.Linq;

namespace AbbyWeb.Services.Repository
{
    public class EmployeeRepository : TuseRepository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext applicationDbContext)
            :base(applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public void Update(Employee employeeToUpdate)
        {
            var findEmployee = _context.Employees.FirstOrDefault(x => x.Id == employeeToUpdate.Id);
            if(findEmployee!= null)
            {
                findEmployee.FirstName = employeeToUpdate.FirstName;
                findEmployee.LastName = employeeToUpdate.LastName;
                findEmployee.Address = employeeToUpdate.Address;
                findEmployee.Dob = employeeToUpdate.Dob;
                findEmployee.Salary = employeeToUpdate.Salary;
                findEmployee.TimeRecorded = DateTime.Now.TimeOfDay;
                findEmployee.Telephone = employeeToUpdate.Telephone;
                findEmployee.GenderId = employeeToUpdate.GenderId;
                findEmployee.OccupationId = employeeToUpdate.OccupationId;
                _context.SaveChanges();
            }

          
        }
    }
}
