using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Business_Logic;
using soft20181_starter.Models;

namespace soft20181_starter.Pages
{
    public class UpdateAccountModel : PageModel
    {
        public Account Account { get; set; } = new Account();
        public void OnGet()
        {
            int id = Convert.ToInt32(Request.Query["id"]);
            try
            {
                Account = AccountOperation.GetAccount(id);
            }
            catch (Exception ex) { return; }
        }
        public void OnPost()
        {
            Account.Id = Convert.ToInt32(Request.Form["id"]);
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
                AccountOperation.UpdateAccounts(Account);
            }
            catch (Exception ex)
            {
                return;
            }
            Response.Redirect("/AdminAccounts");
        }
    }
}
