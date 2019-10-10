using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetDinos.Data;

namespace PetDinos.Pages.PetStores
{
    public class CreateModel : PageModel
    {
        private readonly PetDinos.Data.ApplicationDbContext _context;

        public CreateModel(PetDinos.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PetStore PetStore { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PetStore.Add(PetStore);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}