using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Business_Logic;
using soft20181_starter.Models;

namespace soft20181_starter.Pages
{
    public class AdminAccountsModel : PageModel
    {
        public List<Account> accounts = new List<Account>();
        public string ErrorMsg = "";
        public async Task OnGetAsync()
        {
            try
            {
                await Task.Run(LoadAccounts);
            }
            catch (Exception ex)
            {
                ErrorMsg = ex.ToString();
                return;
            }

        }
        public void LoadAccounts()
        {
            accounts = AccountOperation.GetAccounts();
        }
    }
}
