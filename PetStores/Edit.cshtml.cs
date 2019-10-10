using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetDinos.Data;

namespace PetDinos.Pages.PetStores
{
    public class EditModel : PageModel
    {
        private readonly PetDinos.Data.ApplicationDbContext _context;

        public EditModel(PetDinos.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PetStore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetStoreExists(PetStore.PSID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PetStoreExists(int id)
        {
            return _context.PetStore.Any(e => e.PSID == id);
        }
    }
}
