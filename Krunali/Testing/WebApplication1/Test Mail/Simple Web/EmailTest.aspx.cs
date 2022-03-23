using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

namespace Test_Mail.Simple_Web
{
    public partial class EmailTest : System.Web.UI.Page
    {
        static string smtpAddress = "smtp.gmail.com";
        static int portNumber = 587;
        static bool enableSSL = true;
        static string emailFromAddress = "krunaligohil209@gmail.com"; //Sender Email Address  
        static string password = "parkavenue@123"; //Sender Password  
        static string emailToAddress = "kyg_18@yahoo.in"; //Receiver Email Address  
        static string subject = "Hello";
        static string body = "Hello, This is Email sending test using gmail.";

        protected void Page_Load(object sender, EventArgs e)
        {
            sendMail();
        }



        public void sendMail()
        {
            MailMessage mail = new MailMessage();
            //SmtpClient SmtpServer = new SmtpClient("smtp.google.com");
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            // SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587);
            mail.From = new MailAddress("krunaligohil209@gmail.com");
            mail.To.Add("kyg_18@yahoo.in");
            mail.Subject = "Intro";
            mail.Body = "Hi,,";
            mail.IsBodyHtml = true;
            HttpFileCollection hfc = Request.Files;
            //for (int i = 0; i < hfc.Count; i++)
            //{
            //    HttpPostedFile hpf = hfc[i];
            //    if (hpf.ContentLength > 0)
            //    {
            //        mail.Attachments.Add(new Attachment(fupload.PostedFile.InputStream, hpf.FileName));

            //    }
            //}


            SmtpServer.Port = 25;
            //SmtpServer.Host = "smtp.gmail.com";
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential("krunaligohil209@gmail.com", "parkavenue@123");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", "dim('Mail Sent Successfully..!');", true);
            mail.Dispose();

            //'=============='============================================
            _ = new MailMessage();
            _ = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("krunaligohil209@gmail.com");
            mail.To.Add("kyg_18@yahoo.in");
            mail.Subject = "Test Mail - 1";
            mail.Body = "mail with attachment";

           
            //attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
            //mail.Attachments.Add(attachment);


            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("krunaligohil209@gmail.com", "parkavenue@123");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

            //using (MailMessage mail = new MailMessage())
            //{
            //    mail.From = new MailAddress(emailFromAddress);
            //    mail.To.Add(emailToAddress);
            //    mail.Subject = subject;
            //    mail.Body = body;
            //    mail.IsBodyHtml = true;
            //    //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
            //    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
            //    {
            //        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //        smtp.UseDefaultCredentials = false;
            //        smtp.EnableSsl = enableSSL;
            //        smtp.Credentials = new NetworkCredential(emailFromAddress, password);
            //         smtp.Send(mail);
            //    }
            //}
        }
    }
}