using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetDinos.Data;

namespace PetDinos.Pages.Dinosaurs
{
    public class EditModel : PageModel
    {
        private readonly PetDinos.Data.ApplicationDbContext _context;

        public EditModel(PetDinos.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dinosaur Dinosaur { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dinosaur = await _context.Dinosaur
                .Include(d => d.PetStore).FirstOrDefaultAsync(m => m.DID == id);

            if (Dinosaur == null)
            {
                return NotFound();
            }
           ViewData["PSID"] = new SelectList(_context.PetStore, "PSID", "PSID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Dinosaur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DinosaurExists(Dinosaur.DID))
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

        private bool DinosaurExists(int id)
        {
            return _context.Dinosaur.Any(e => e.DID == id);
        }
    }
}
