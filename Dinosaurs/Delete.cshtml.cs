using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetDinos.Data;

namespace PetDinos.Pages.Dinosaurs
{
    public class DeleteModel : PageModel
    {
        private readonly PetDinos.Data.ApplicationDbContext _context;

        public DeleteModel(PetDinos.Data.ApplicationDbContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dinosaur = await _context.Dinosaur.FindAsync(id);

            if (Dinosaur != null)
            {
                _context.Dinosaur.Remove(Dinosaur);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
