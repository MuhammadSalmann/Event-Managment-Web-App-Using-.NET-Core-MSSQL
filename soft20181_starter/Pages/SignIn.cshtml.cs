using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using soft20181_starter.Business_Logic;
using soft20181_starter.Models;

namespace soft20181_starter.Pages
{
    public class SignInModel : PageModel
    {
        public Account Account { get; set; } = new Account();
        public string Email { get; set; }
        public string Password { get; set; }
        
        //Creating Session
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SignInModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void OnPost()
        {
            Email = Request.Form["email"];
            Password = Request.Form["password"];
            if (Email.Length == 0 || Password.Length == 0) { return; }

            try
            {
                Account = AccountOperation.CheckAccount(Email, Password);
                if (Account == null) 
                {
                    TempData["ErrorMessage"] = "Incorrect email or password!";
                    return; 
                }
                // Storing in Role in Session
                _httpContextAccessor.HttpContext.Session.SetString("UserRole", Account.Role);
                // Set session variable to indicate that the user is logged in
                HttpContext.Session.SetString("IsLoggedIn", "true");
                
            }
            catch(Exception ex) { return; }
            Response.Redirect($"/index?role={Account.Role}&name={Account.Name}");
        }
    }
}
