using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesMovie.Pages
{
    public class ContactModel : PageModel
    {
        #region Properties

        public string Message { get; set; }

        #endregion

        #region Actions

        public void OnGet()
        {
            this.Message = "Your contact page.";
        }

        #endregion
    }
}