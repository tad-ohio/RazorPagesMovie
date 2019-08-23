using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class DeleteModel : PageModel
    {
        #region Variables

        private readonly RazorPagesMovieContext _context;

        #endregion

        #region Constructors

        public DeleteModel(RazorPagesMovieContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            this.Movie = await this._context.Movie.FindAsync(id);

            if (this.Movie != null)
            {
                this._context.Movie.Remove(Movie);
                await this._context.SaveChangesAsync();
            }

            return RedirectToPage("../Index");
        }

        #endregion
    }
}