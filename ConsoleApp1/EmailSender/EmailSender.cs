using iText.Forms.Fields;
using iText.IO.Image;
using iText.Kernel.Pdf.Canvas.Wmf;
using iText.Kernel.Pdf.Xobject;
using iText.Kernel.Pdf;
using iText.Signatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using iText.Forms;
using iText.Layout;
using System.Net.Mime;
using System.Net;

namespace ConsoleApp1.EmailSender
{
    public class EmailSender
    {
        public void EmailSenderProcess(MemoryStream ms)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("teste@gmail.com");
                mail.To.Add("teste2@gmail.com");
                mail.Subject = "Teste";
                mail.Body = "Testando mensagem de e-mail";
                ms.Position = 0;
                ms.Seek(0, SeekOrigin.Begin);
                mail.Attachments.Add(new Attachment(ms, "ArquivoDeTeste2.pdf"));

                using (var smtp = new SmtpClient("smtp.gmail.com"))
                {
                    smtp.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtp.PickupDirectoryLocation = @"C:\Users\Usuario\Downloads\";

                    smtp.Send(mail);

                    smtp.SendCompleted += (s, e) =>
                    {
                        smtp.Dispose();
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
