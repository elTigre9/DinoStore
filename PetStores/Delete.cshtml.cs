using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetDinos.Data;

namespace PetDinos.Pages.PetStores
{
    public class DeleteModel : PageModel
    {
        private readonly PetDinos.Data.ApplicationDbContext _context;

        public DeleteModel(PetDinos.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PetStore PetStore { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PetStore = await _context.PetStore.FirstOrDefaultAsync(m => m.PSID == id);

            if (PetStore == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PetStore = await _context.PetStore.FindAsync(id);

            if (PetStore != null)
            {
                _context.PetStore.Remove(PetStore);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
