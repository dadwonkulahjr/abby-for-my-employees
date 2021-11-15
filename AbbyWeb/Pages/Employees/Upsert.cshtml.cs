using AbbyWeb.Services.Repository.IRepository;
using AbbyWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace AbbyWeb.Pages.Employees
{
    [BindProperties]
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public EmployeeViewModel EmployeeViewModel { get; set; } = new();

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {

                EmployeeViewModel.Employee = new();

                EmployeeViewModel.GetDropdownListForGender = _unitOfWork
                    .GenderRepository.RetrievedAll()
                    .Select(x => new SelectListItem()
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }).ToList();

                EmployeeViewModel.GetDropdownListForOccupation = _unitOfWork
                    .OccupationRepository.RetrievedAll()
                    .Select(x => new SelectListItem()
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }).ToList();
                return Page();
            }

            if (id.HasValue)
            {
                EmployeeViewModel.Employee = _unitOfWork.EmployeeRepository.RetrievedAll(filterData: e => e.Id == id.Value, navigationProperties: "Gender,Occupation").FirstOrDefault();

                EmployeeViewModel.GetDropdownListForGender = _unitOfWork
                    .GenderRepository.RetrievedAll()
                    .Select(x => new SelectListItem()
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }).ToList();

                EmployeeViewModel.GetDropdownListForOccupation = _unitOfWork
                    .OccupationRepository.RetrievedAll()
                    .Select(x => new SelectListItem()
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }).ToList();

                if (EmployeeViewModel.Employee == null)
                {
                    return NotFound();
                }

                return Page();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                EmployeeViewModel.GetDropdownListForGender = _unitOfWork
                   .GenderRepository.RetrievedAll()
                   .Select(x => new SelectListItem()
                   {
                       Text = x.Name,
                       Value = x.Id.ToString()
                   }).ToList();

                EmployeeViewModel.GetDropdownListForOccupation = _unitOfWork
                    .OccupationRepository.RetrievedAll()
                    .Select(x => new SelectListItem()
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }).ToList();
                return Page();
            }


            if (EmployeeViewModel.Employee.Id == 0)
            {
                _unitOfWork.EmployeeRepository.Add(EmployeeViewModel.Employee);
                EmployeeViewModel.Employee.TimeRecorded = DateTime.Now.TimeOfDay;
                _unitOfWork.SaveToDb();
                TempData["success"] = "Employee was added successfully!";
                return RedirectToPage("index");
            }
            else
            {
                var checkForEmployee = _unitOfWork.EmployeeRepository.Find(EmployeeViewModel.Employee.Id);
                if (checkForEmployee == null)
                {
                    return NotFound();
                }

                _unitOfWork.EmployeeRepository.Update(EmployeeViewModel.Employee);
                EmployeeViewModel.Employee.TimeRecorded = DateTime.Now.TimeOfDay;
                TempData["success"] = "Employee was updated successfully!";
                return RedirectToPage("index");
            }




            return Page();
        }
    }
}
