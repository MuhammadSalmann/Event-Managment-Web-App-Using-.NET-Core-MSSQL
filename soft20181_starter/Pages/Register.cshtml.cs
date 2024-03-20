using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Business_Logic;
using soft20181_starter.Models;

namespace soft20181_starter.Pages
{
    public class RegisterModel : PageModel
    {
        public Account Account { get; set; } = new Account();
        public void OnPost()
        {
            Account.Name = Request.Form["name"];
            Account.Email = Request.Form["email"];
            Account.Password = Request.Form["password"];
            if (Account.Name.Length == 0 || Account.Email.Length == 0 ||
                Account.Password.Length == 0)
            {
                return;
            }

            try
            {
                AccountOperation.CreateAccount(Account);
                Response.Redirect("/SignIn");
            }
            catch(Exception ex) { return; }
        }
    }
}
