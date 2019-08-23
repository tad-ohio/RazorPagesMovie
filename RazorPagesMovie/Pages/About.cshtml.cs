using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesMovie.Pages
{
    public class AboutModel : PageModel
    {
        #region Properties

        public string Message { get; set; }

        #endregion

        #region Actions

        public void OnGet()
        {
            this.Message = "Your movie repository.";
        }

        #endregion
    }
}