using System.Net.Mail;
using System.Net;
using TravelAgencyAPI.Models;

namespace TravelAgencyAPI.Services
{
    public class SendEmail
    {
        public void SendConfirmationEmail(string toEmail, Reservation reservation)
        {
            var client = new SmtpClient("smtp.example.com")
            {
                Credentials = new NetworkCredential("username", "password"),
                EnableSsl = true
            };

            var mail = new MailMessage
            {
                From = new MailAddress("no-reply@travelagency.com"),
                Subject = "Reservation Confirmation",
                Body = $"Dear {reservation.GuestId},\nYour reservation has been confirmed.\nDetails:\n- Check-In: {reservation.CheckInDate}\n- Check-Out: {reservation.CheckOutDate}\nThank you!",
                IsBodyHtml = false
            };

            mail.To.Add(toEmail);
            client.Send(mail);
        }

    }
}
