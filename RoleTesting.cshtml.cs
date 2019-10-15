using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PetDinos.Pages
{
    public class RoleTestingModel : PageModel
    {
        public string CurrentUserRole { get; set; }
        public void OnGet()
        {
            CurrentUserRole = "DH";
        }
    }
}