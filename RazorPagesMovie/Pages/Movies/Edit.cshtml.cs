using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class EditModel : PageModel
    {
        #region Variables

        private readonly RazorPagesMovieContext _context;

        #endregion

        #region Constructors

        public EditModel(RazorPagesMovieContext context)
        {
            this._context = context;
        }

        #endregion

        #region Properties

        [BindProperty]
        public Movie Movie { get; set; }

        #endregion

        #region Actions

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            this.Movie = await this._context.Movie.FirstOrDefaultAsync(m => m.ID == id);

            if (this.Movie == null)
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

            _context.Attach(Movie).State = EntityState.Modified;

            try
            {
                await this._context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(Movie.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../Index");
        }

        private bool MovieExists(int id)
        {
            return this._context.Movie.Any(e => e.ID == id);
        }

        #endregion
    }
}