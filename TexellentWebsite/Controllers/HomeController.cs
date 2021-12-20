using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using TexellentWebsite.Models;

namespace TexellentWebsite.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ContactViewModel cvm)
        {
            string smptHost = Convert.ToString(ConfigurationManager.AppSettings["SmtpHost"]);
            string to = Convert.ToString(ConfigurationManager.AppSettings["To"]);
            int smtpPort = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpPort"]);
            string mailAddress = Convert.ToString(ConfigurationManager.AppSettings["MailAddress"]);
            string mailFrom = Convert.ToString(ConfigurationManager.AppSettings["MailFrom"]);
            string mailPassword = Convert.ToString(ConfigurationManager.AppSettings["MailPassword"]);
            bool isEnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["IsEnableSsl"]);
            int mailTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["MailTimeout"]);
            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            string msg = string.Empty;
            try
            {
                MailAddress fromAddress = new MailAddress(mailAddress);
                message.From = fromAddress;
                message.To.Add(to);
                message.Subject = "Enquiry from Texellent Solutions";
                message.IsBodyHtml = true;
                message.Body = "Name:" + cvm.Name + " Email: " + cvm.Email + " Subject:" + cvm.Subject + " Message:" + cvm.Message;
                smtpClient.Host = smptHost;   //-- Donot change.
                smtpClient.Port = smtpPort; //--- Donot change
                smtpClient.EnableSsl = isEnableSsl;//--- Donot change
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new System.Net.NetworkCredential(mailAddress, mailPassword);

                smtpClient.Send(message);
                TempData["successmsg"] = "Your email successfully sent.";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                TempData["errormsg"] = "Something went wrong. Please try again later";
            }
            return View();
        }
        protected void btnSendEmail_Click(ContactViewModel cvm)
        {
            string smptHost = Convert.ToString(ConfigurationManager.AppSettings["SmtpHost"]);
            string to = Convert.ToString(ConfigurationManager.AppSettings["To"]);
            int smtpPort = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpPort"]);
            string mailAddress = Convert.ToString(ConfigurationManager.AppSettings["MailAddress"]);
            string mailFrom = Convert.ToString(ConfigurationManager.AppSettings["MailFrom"]);
            string mailPassword = Convert.ToString(ConfigurationManager.AppSettings["MailPassword"]);
            bool isEnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["IsEnableSsl"]);
            int mailTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["MailTimeout"]);
            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            string msg = string.Empty;
            try
            {
                MailAddress fromAddress = new MailAddress(mailAddress);
                message.From = fromAddress;
                message.To.Add(to);
                message.Subject = "Enquiry from Texellent Solutions";
                message.IsBodyHtml = true;
                message.Body = "Name:" + cvm.Name + " Email: " + cvm.Email + " Subject:" + cvm.Subject + " Message:" + cvm.Message;
                smtpClient.Host = smptHost;   //-- Donot change.
                smtpClient.Port = smtpPort; //--- Donot change
                smtpClient.EnableSsl = isEnableSsl;//--- Donot change
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new System.Net.NetworkCredential(mailAddress, mailPassword);

                smtpClient.Send(message);
                TempData["successmsg"] = "Your email successfully sent.";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                TempData["errormsg"] = "Something went wrong. Please try again later";
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult PrivacyPolicy()
        {
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult RPA()
        {
            return View();
        }
    }
}