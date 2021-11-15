using AbbyWeb.Models;


namespace AbbyWeb.Services.Repository.IRepository
{
    public interface IEmployeeRepository : IAmtuseRepository<Employee>
    {
        void Update(Employee employeeToUpdate);
    }
}
