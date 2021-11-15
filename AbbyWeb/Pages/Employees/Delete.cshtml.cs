using AbbyWeb.Models;
using AbbyWeb.Services.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace AbbyWeb.Pages.Employees
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Employee Employee { get; set; }

        public IActionResult OnGet(int id)
        {
            Employee = _unitOfWork.EmployeeRepository.RetrievedAll(filterData: e => e.Id == id, navigationProperties: "Gender,Occupation").FirstOrDefault();

            if (Employee == null)
            {
                return NotFound();
            }

            return Page();

        }


        public IActionResult OnPost(int id)
        {
            var empFound = _unitOfWork.EmployeeRepository.Find(id);

            if (empFound != null)
            {
                _unitOfWork.EmployeeRepository.Delete(empFound.Id);
                _unitOfWork.SaveToDb();
                TempData["success"] = $"Employee {empFound.FullName} was deleted successfully!";
                return RedirectToPage("index");
            }

            return Page();
        }
    }
}
