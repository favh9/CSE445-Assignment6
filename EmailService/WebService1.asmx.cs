using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Services;

namespace EmailService
{
    
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string SendEmail(string toEmail, string message)
        {
            try
            {
                // SMTP setup (use your own credentials)
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("faris.testing962@gmail.com", "fplchjxnukavlhdi"),
                    EnableSsl = true
                };

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("faris.testing962@gmail.com");
                msg.To.Add(toEmail);
                msg.Subject = "Message from Assignment 5 Web Service";
                msg.Body = message;

                client.Send(msg);
                return "Email sent successfully to: " + toEmail;
            }
            catch (Exception ex)
            {
                return "Error sending email: " + ex.Message;
            }
        }
    }
}