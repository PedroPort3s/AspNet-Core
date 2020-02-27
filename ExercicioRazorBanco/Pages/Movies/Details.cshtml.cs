using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ExercicioRazorBanco.Data;
using ExercicioRazorBanco.Model;

namespace ExercicioRazorBanco
{
    public class DetailsModel : PageModel
    {
        private readonly ExercicioRazorBanco.Data.ExercicioRazorBancoContext _context;

        public DetailsModel(ExercicioRazorBanco.Data.ExercicioRazorBancoContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movie.FirstOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
