using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using soft20181_starter.DataAccess;
using soft20181_starter.Models;
using System.Security.Cryptography.Pkcs;

namespace soft20181_starter.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public Contact ContactInfo { get; set; } = new Contact();
        public String ErrorMsg { get; set; } = "";
        public String SuccessMsg { get; set; } = "";

        public void OnPost()
        {
            ContactInfo.Name = Request.Form["name"];
            ContactInfo.Email = Request.Form["email"];
            ContactInfo.Phone = Request.Form["phone"];
            ContactInfo.Subject = Request.Form["subject"];
            ContactInfo.Message = Request.Form["message"];

            if(ContactInfo.Name.Length == 0 || ContactInfo.Email.Length == 0 ||
                ContactInfo.Phone.Length == 0 || ContactInfo.Message.Length == 0)
            {
                ErrorMsg = "Fill all the Fields";
                return;
            }
            try
            {
            SqlConnection conn = DBHelper.GetConnection();
            conn.Open();
            String query = "INSERT INTO Contact (Name, Email, Phone, Subject, Message) VALUES" +
                "(@Name, @Email, @Phone, @Subject, @Message)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", ContactInfo.Name);
            cmd.Parameters.AddWithValue("@Email", ContactInfo.Email);
            cmd.Parameters.AddWithValue("@Phone", ContactInfo.Phone);
            cmd.Parameters.AddWithValue("@Subject", ContactInfo.Subject);
            cmd.Parameters.AddWithValue("@Message", ContactInfo.Message);
            cmd.ExecuteNonQuery();
            conn.Close();
            }
            catch(Exception ex)
            {
                ErrorMsg = ex.ToString();
                return;
            }

            ContactInfo.Name = "";
            ContactInfo.Email = "";
            ContactInfo.Phone = "";
            ContactInfo.Subject = "";
            ContactInfo.Message = "";
            SuccessMsg = "Successfully Stored";
            Response.Redirect("/");
        }
    }
}
