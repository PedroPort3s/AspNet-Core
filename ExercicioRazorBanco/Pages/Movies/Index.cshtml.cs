using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ExercicioRazorBanco.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace ExercicioRazorBanco
{
    public class IndexModel : PageModel
    {
        private readonly Data.ExercicioRazorBancoContext _context;

        public IndexModel(Data.ExercicioRazorBancoContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        [BindProperty(SupportsGet =true)]
        public string StrPesquisa { get; set; }
        public SelectList Generos { get; set; }

        [BindProperty(SupportsGet = true)]
        public string GeneroFilme { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> generoQuery = from m in _context.Movie orderby m.Genero select m.Genero;

            var movies = from m in _context.Movie select m;

            if (!string.IsNullOrEmpty(StrPesquisa))
            {
                movies = movies.Where(s => s.Titulo.Contains(StrPesquisa));
            }
            if (!string.IsNullOrEmpty(GeneroFilme))
            {
                movies = movies.Where(x => x.Genero == GeneroFilme);
            }

            Generos = new SelectList(await generoQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }
    }
}
