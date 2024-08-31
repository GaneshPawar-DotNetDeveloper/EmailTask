using Send_Email_MVC_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Send_Email_MVC_.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Index()
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult SendEmail(EmailModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    SmtpClient client = new SmtpClient("smtp.gmail.com")
                    {
                        Port = 587, // Use 465 for SSL or 587 for TLS
                        Credentials = new NetworkCredential("itsganeshpawar99@gmail.com", "pdqi apaz mfyu upms"),
                        EnableSsl = true, // Use SSL/TLS
                    };

                    MailMessage mailMessage = new MailMessage
                    {
                        From = new MailAddress("itsganeshpawar99@gmail.com"),
                        Subject = model.Subject,
                        Body = model.Body,
                        IsBodyHtml = false,
                    };

                    mailMessage.To.Add(model.To);

                    client.Send(mailMessage);
                    ViewBag.Message = "Email successfully sent!";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = $"Error: {ex.Message}";
                }
            }

            return View("Index", model);
        }
    }
}
    
