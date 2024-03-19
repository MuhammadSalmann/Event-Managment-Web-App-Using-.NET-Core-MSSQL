using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Models;

namespace soft20181_starter.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public Contact ContactInfo { get; set; } = new Contact(); // Initialize to ensure it's never null

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // Logic for handling a valid form submission goes here
                // For example, saving data to a database

                return RedirectToPage("SomeSuccessPage"); // Redirect to a success page
            }

            // Return to the page to display validation errors
            return Page();
        }
    }
}
