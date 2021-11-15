using AbbyWeb.Models;
using AbbyWeb.Services.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace AbbyWeb.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IEnumerable<Employee> Employees { get; set; }
        //[TempData]
        //public string Success { get; set; }
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
            Employees = _unitOfWork.EmployeeRepository.RetrievedAll(navigationProperties: "Gender,Occupation");
        }
    }
}
