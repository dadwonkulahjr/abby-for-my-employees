using AbbyWeb.Services.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AbbyWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _unitOfWork.EmployeeRepository.RetrievedAll(navigationProperties: "Gender,Occupation")
                        .Select(e => new
                        {
                            id = e.Id,
                            fullName = e.FullName,
                            firstName = e.FirstName,
                            lastName = e.LastName,
                            address = e.Address,
                            telephone = e.Telephone,
                            salary = e.Salary.Value.ToString("c"),
                            dob = e.Dob.Value.ToShortDateString(),
                            gender = e.Gender.Name,
                            occupation = e.Occupation.Name
                        })
                        .OrderBy(e => e.fullName)
                        .ToList();

            return Json(new { data = list });
                        
        }
    }
}
