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
    public class IndexModel : PageModel
    {
        private readonly PetDinos.Data.ApplicationDbContext _context;

        public IndexModel(PetDinos.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Dinosaur> Dinosaur { get;set; }

        public async Task OnGetAsync()
        {
            Dinosaur = await _context.Dinosaur
                .Include(d => d.PetStore).ToListAsync();

            
        }
    }
}
