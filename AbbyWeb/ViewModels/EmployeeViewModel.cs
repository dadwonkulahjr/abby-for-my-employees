using AbbyWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AbbyWeb.ViewModels
{
    public class EmployeeViewModel
    {
        public IEnumerable<SelectListItem> GetDropdownListForGender { get; set; }
        public IEnumerable<SelectListItem> GetDropdownListForOccupation { get; set; }
        public Employee Employee { get; set; }

    }
}
