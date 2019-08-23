using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class CreateModel : PageModel
    {
        #region Variables

        private readonly RazorPagesMovieContext _context;

        #endregion

        #region Constructors

        public CreateModel(RazorPagesMovieContext context)
        {
            this._context = context;
        }

        #endregion

        #region Properties

        [BindProperty]
        public Movie Movie { get; set; }

        #endregion

        #region Actions

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            this._context.Movie.Add(this.Movie);
            await this._context.SaveChangesAsync();

            return RedirectToPage("../Index");
        }

        #endregion
    }
}