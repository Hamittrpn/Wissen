using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Wissen.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DenemeForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DenemeForm(Wissen.Models.DenemeForm model)
        {
            if (ModelState.IsValid)
            {
                bool hasError = false;
                try
                {
                    System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
                    mailMessage.From = new System.Net.Mail.MailAddress("hamittirpan@gmail.com");
                    mailMessage.Subject = "İletişim Formu: " + model.FirstName + " " + model.LastName;
                    mailMessage.To.Add("hamittirpan@gmail.com");

                    string body;
                    body = "Ad Soyad: " + model.FirstName + " " + model.LastName + "<br />";
                    body += "Telefon: " + model.Phone + "<br />";
                    body += "E-posta: " + model.Email + "<br />";
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Body = body;

                    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
                    smtp.Credentials = new System.Net.NetworkCredential("hamittirpan@gmail.com", "b1205.020036");
                    smtp.EnableSsl = true;
                    smtp.Send(mailMessage);
                   
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                    hasError = true;
                }
                if (hasError == false)
                {
                    ViewBag.Message = "Mail başarıyla gönderildi.";
                }
                return View();
            }
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Contact(string name, string lastName, string Email,string phone,string message,string departmant)
        {
            name = name.Trim();
            lastName = lastName.Trim();

            if (name == "") // Trim ile kullanıcının boşluk tuşu ile boşluk vermesi engelleniyor.
            {
                ViewBag.Message = "İsim alanı gereklidir !";
                ViewBag.IsError = true;
                return View();
            }
            if (name.Length > 50)
            {
                ViewBag.Message = "İsim alanı 50 karakterden büyük olamaz !";
                ViewBag.IsError = true;
                return View();
            }
            if (lastName == "")
            {
                ViewBag.Message = "Soyisim alanı gereklidir !";
                ViewBag.IsError = true;
                return View();
            }
            if (lastName.Length > 50)
            {
                ViewBag.Message = "Soyisim alanı 50 karakterden büyük olamaz !";
                ViewBag.IsError = true;
                return View();
            }
            if (Email == "")
            {
                ViewBag.Message = "E-posta alanı gereklidir !";
                ViewBag.IsError = true;
                return View();
            }
            Regex regex = new Regex(@" ^ 5(0[5 - 7] | [3 - 5]\d) ?\d{ 3 } ?\d{ 4}$");
            Match match = regex.Match(phone);

            if (match.Success == false)
            {
                ViewBag.Message = "Telefon 5XX XXX XXXX biçiminde olmalıdır !";
                ViewBag.IsError = true;
                return View();
            }

            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.From = new System.Net.Mail.MailAddress("hamittirpan@gmail.com");
            mailMessage.Subject = "İletişim Formu: " + name + lastName;
            mailMessage.To.Add("hamittirpan@gmail.com");

            string body;
            body = "Ad Soyad: " + name + " " + lastName + "<br />";
            body += "Telefon: " + phone + "<br />";
            body += "E-posta: " + Email + "<br />";
            body += "Mesaj: " + message + "<br />";
            body += "Departman: " + departmant + "<br />";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = body;

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new System.Net.NetworkCredential("hamittirpan@gmail.com", "b1205.020036");
            smtp.EnableSsl = true;
            smtp.Send(mailMessage);
            
            ViewBag.Message = "Form başarıyla iletildi, en kısa zamanda dönüş yapacağız.";
            return View();
        }
    }
}