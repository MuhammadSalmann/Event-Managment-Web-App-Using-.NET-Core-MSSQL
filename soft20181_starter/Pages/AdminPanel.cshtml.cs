using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Business_Logic;
using soft20181_starter.Models;

namespace soft20181_starter.Pages
{
    public class AdminPanelModel : PageModel
    {
        public List<Booking> bookings = new List<Booking>();
        public string ErrorMsg = "";
        public int DeleteId = 0;
        public async Task OnGetAsync()
        {
            try
            {
                await Task.Run(LoadBookings);
            }
            catch (Exception ex)
            {
                ErrorMsg = ex.ToString();
                return;
            }
            
        }
        public void LoadBookings()
        {
            //await Task.Delay(5000);
            bookings = EventOperation.GetBookings();
        }
    }
}
