using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        #region Variables

        private readonly RazorPagesMovieContext _context;

        #endregion

        #region Constructors

        public IndexModel(RazorPagesMovieContext context)
        {
            this._context = context;
        }

        #endregion

        #region Properties

        public IList<Movie> Movie { get; set; }

        #endregion

        #region Actions

        public async Task OnGetAsync()
        {
            this.Movie = await this._context.Movie.ToListAsync();
        }

        #endregion
    }
}