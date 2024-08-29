using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;

namespace BusinessAccessLayer
{
    public class EmailRepository:IEmailRepository
    {
        private readonly IConfiguration Configuration;
        public EmailRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void SendEmail(string fromAddress, string password, string toaddress, string subject, string body)
        {
            using SmtpClient email = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential(fromAddress, password)

            };
            try
            {
                Console.WriteLine("Sending Email **********");
                email.Send(fromAddress, toaddress, subject, body);
                Console.WriteLine("Email sent");

            }
            catch (SmtpException e)
            {
                throw;
            }
        }
    }
}
