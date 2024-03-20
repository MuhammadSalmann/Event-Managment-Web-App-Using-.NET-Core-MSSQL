using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using soft20181_starter.Business_Logic;
using soft20181_starter.Models;

namespace soft20181_starter.Pages
{
    public class UpdateBookingModel : PageModel
    {
        public Booking Booking { get; set; } = new Booking();
        public void OnGet() 
        {
            int id = Convert.ToInt32(Request.Query["id"]);
            try
            {
                Booking = EventOperation.GetBooking(id);
            }
            catch (Exception ex) { return; }
        }
        public void OnPost()
        {
            Booking.Id = Convert.ToInt32(Request.Form["id"]);
            Booking.Event = Request.Form["events"];
            Booking.Location = Request.Form["location"];
            Booking.Name = Request.Form["name"];
            Booking.Phone = Request.Form["phone"];
            Booking.Tickets = Convert.ToInt32(Request.Form["tickets"]);

            if (Booking.Name.Length == 0 || Booking.Tickets == 0 ||
                Booking.Phone.Length == 0)
            {
                return;
            }
            try
            {
                EventOperation.UpdateBooking(Booking);
            }
            catch (Exception ex)
            {
                return;
            }
            Response.Redirect("/AdminPanel");
        }
    }
}
