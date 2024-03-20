using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using soft20181_starter.Business_Logic;
using soft20181_starter.DataAccess;
using soft20181_starter.Models;
using System.Security.Cryptography.Pkcs;

namespace soft20181_starter.Pages
{
    public class BookingModel : PageModel
    {
        public Booking Booking { get; set; } = new Booking();
        public String ErrorMsg { get; set; } = "";
        public String SuccessMsg { get; set; } = "";

        public void OnPost()
        {
            Booking.Event = Request.Form["events"];
            Booking.Location = Request.Form["location"];
            Booking.Name = Request.Form["name"];
            Booking.Phone = Request.Form["tel"];
            Booking.Tickets = Convert.ToInt32(Request.Form["tickets"]);



            if (Booking.Name.Length == 0 || Booking.Tickets == 0 ||
                Booking.Phone.Length == 0 || Booking.Event.Length == 0 ||
                Booking.Location.Length == 0 ) 
            {
                ErrorMsg = "Fill all the Fields";
                return;
            }
            try
            {
                EventOperation.CreateBooking(Booking);
            }
            catch (Exception ex)
            {
                ErrorMsg = ex.ToString();
                return;
            }

            Booking.Name = "";
            Booking.Location = "";
            Booking.Phone = "";
            Booking.Event = "";
            Booking.Tickets = 0;
            SuccessMsg = "Successfully Stored";
            Response.Redirect("/");
        }
    }
}
